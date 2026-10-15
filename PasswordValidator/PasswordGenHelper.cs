using System.Numerics;

namespace PasswordValidator
{
    /// <summary>
    /// Especifica el tipo de caracteres disponibles para la generación de contraseñas.
    /// </summary>
    public enum CharType
    {
        /// <summary>Letras minúsculas (a-z)</summary>
        LowerCase,
        /// <summary>Letras mayúsculas (A-Z)</summary>
        UpperCase,
        /// <summary>Dígitos numéricos (0-9)</summary>
        Digits,
        /// <summary>Símbolos especiales (!@#$%^&amp;*()_+-={}[]\|;:'"&lt;&gt;,.?/~`)</summary>
        Symbols
    }

    /// <summary>
    /// Clase auxiliar para generar contraseñas aleatorias y calcular las posibilidades de combinaciones de contraseñas.
    /// Proporciona métodos para generar contraseñas seguras basadas en restricciones de configuración especificadas
    /// y calcular el número total de combinaciones de contraseña válidas.
    /// </summary>
    /// <remarks>
    /// Es la única fuente de verdad para la generación y el cálculo combinatorio: la interfaz de usuario
    /// (<see cref="MainForm"/>) delega en esta clase y en <see cref="SecureRandom"/> en lugar de reimplementar
    /// la lógica, garantizando aleatoriedad criptográficamente segura y conteos coherentes con los caracteres usados.
    /// </remarks>
    public class PasswordGenHelper
    {
        /// <summary>
        /// Genera una contraseña aleatoria basada en la configuración proporcionada.
        /// </summary>
        /// <param name="generateConfig">Objeto de configuración que especifica las restricciones de la contraseña incluyendo:
        /// - Length: longitud deseada de la contraseña
        /// - Banderas de tipo de carácter (IsLowerCase, IsUpperCase, IsDigits, IsSymbols)
        /// - MustStartWithUpperCase: si es verdadero, la contraseña debe comenzar con una letra mayúscula (tiene
        ///   prioridad sobre MustStartWithLetter)
        /// - MustStartWithLetter: si es verdadero, la contraseña debe comenzar con una letra
        /// - MustContainAtLeastOneDigit: si es verdadero, la contraseña debe contener al menos un dígito</param>
        /// <returns>Una contraseña generada aleatoriamente que coincide con las restricciones de configuración, o una cadena vacía
        /// si la configuración es inválida (sin caracteres disponibles, longitud &lt;= 0 o restricción de inicio imposible)</returns>
        /// <remarks>Utiliza un bucle do-while para asegurar que si MustContainAtLeastOneDigit es verdadero (y los dígitos
        /// están habilitados), la contraseña generada contiene al menos un dígito numérico.</remarks>
        public static string GeneratePassword(GenerateConfig generateConfig)
        {
            if (generateConfig == null || generateConfig.Length <= 0)
                return string.Empty;

            List<char> allChars = GetAvailableCharacters(generateConfig);
            List<char> firstChars = GetFirstCharacters(generateConfig);

            if (allChars.Count == 0 || firstChars.Count == 0)
                return string.Empty;

            SecureRandom random = new SecureRandom();

            // La restricción de dígito solo se puede exigir si los dígitos forman parte del alfabeto;
            // de lo contrario el bucle no terminaría nunca.
            bool mustContainDigit = generateConfig.MustContainAtLeastOneDigit && generateConfig.IsDigits;

            string generatedPassword;

            // Bucle do-while para asegurar que cumpla con la restricción de "al menos un dígito"
            do
            {
                char[] result = new char[generateConfig.Length];

                for (int i = 0; i < generateConfig.Length; i++)
                {
                    // La primera posición usa el conjunto restringido (si aplica); el resto, el alfabeto completo.
                    List<char> pool = i == 0 ? firstChars : allChars;
                    result[i] = pool[random.Next(pool.Count)];
                }

                generatedPassword = new string(result);
            } while (mustContainDigit && !generatedPassword.Any(char.IsDigit));

            return generatedPassword;
        }

        /// <summary>
        /// Calcula el número total de combinaciones de contraseña válidas posibles basado en la configuración.
        /// Utiliza matemáticas combinatorias para calcular posibilidades sin generar todas las contraseñas.
        /// </summary>
        /// <param name="generateConfig">Objeto de configuración que especifica las restricciones de la contraseña</param>
        /// <returns>Un <see cref="BigInteger"/> que representa el número total de combinaciones de contraseña válidas.
        /// Devuelve <see cref="BigInteger.Zero"/> si la configuración es inválida o no hay caracteres disponibles.</returns>
        /// <remarks>
        /// <para>El cálculo tiene en cuenta:</para>
        /// <list type="bullet">
        /// <item><description>Restricciones de la primera posición (debe comenzar con mayúscula o con letra si están habilitadas)</description></item>
        /// <item><description>Posibilidades de las posiciones restantes</description></item>
        /// <item><description>Requisito obligatorio de dígito (si está habilitado, excluye todas las combinaciones sin dígitos)</description></item>
        /// </list>
        /// <para>Fórmula sin restricción de dígito: Primera Posición × Todos los Caracteres^(Longitud-1)</para>
        /// <para>Fórmula con restricción de dígito: Total - (Casos inválidos sin dígitos)</para>
        /// </remarks>
        public static BigInteger CalculateTotalCombinations(GenerateConfig generateConfig)
        {
            if (generateConfig == null || generateConfig.Length <= 0)
                return BigInteger.Zero;

            List<char> allChars = GetAvailableCharacters(generateConfig);
            List<char> firstChars = GetFirstCharacters(generateConfig);
            List<char> firstNonDigitChars = firstChars.Where(c => !char.IsDigit(c)).ToList();
            List<char> nonDigitChars = allChars.Where(c => !char.IsDigit(c)).ToList();

            if (allChars.Count == 0 || firstChars.Count == 0)
                return BigInteger.Zero;

            int nAll = allChars.Count;
            int nFirst = firstChars.Count;
            int remainingLength = generateConfig.Length - 1;

            // Caso sin restricción obligatoria de dígito: Posición 1 * Posiciones Restantes
            BigInteger totalSinRestriccion = BigInteger.Multiply(nFirst, BigInteger.Pow(nAll, remainingLength));

            // Si se exige al menos un dígito, restamos los casos donde NO hay ningún dígito
            if (generateConfig.MustContainAtLeastOneDigit && generateConfig.IsDigits)
            {
                BigInteger casosInvalidos = BigInteger.Multiply(firstNonDigitChars.Count, BigInteger.Pow(nonDigitChars.Count, remainingLength));

                return totalSinRestriccion - casosInvalidos;
            }

            return totalSinRestriccion;
        }

        /// <summary>
        /// Determina el conjunto de caracteres permitidos para la primera posición de la contraseña.
        /// </summary>
        /// <param name="config">Objeto de configuración con las restricciones de inicio</param>
        /// <returns>
        /// - Solo letras mayúsculas si <see cref="GenerateConfig.MustStartWithUpperCase"/> está activo (y las mayúsculas están habilitadas)
        /// - Solo letras (minúsculas y/o mayúsculas) si <see cref="GenerateConfig.MustStartWithLetter"/> está activo
        /// - El alfabeto completo en caso contrario
        /// Devuelve una lista vacía si la restricción de inicio no se puede satisfacer.
        /// </returns>
        /// <remarks>La restricción de mayúscula inicial tiene prioridad sobre la de letra inicial, igual que en la interfaz.</remarks>
        private static List<char> GetFirstCharacters(GenerateConfig config)
        {
            if (config.MustStartWithUpperCase)
                return config.IsUpperCase ? GetCharacters(CharType.UpperCase) : new List<char>();

            if (config.MustStartWithLetter)
                return GetLetterCharacters(config);

            return GetAvailableCharacters(config);
        }

        /// <summary>
        /// Método auxiliar que consolida los caracteres disponibles basado en la configuración.
        /// Utilizado tanto por los métodos de generación de contraseña como por el cálculo de combinaciones.
        /// </summary>
        /// <param name="generateConfig">Objeto de configuración que especifica qué tipos de caracteres incluir</param>
        /// <returns>Una lista de todos los caracteres disponibles basados en las banderas de tipo de carácter habilitadas</returns>
        private static List<char> GetAvailableCharacters(GenerateConfig generateConfig)
        {
            List<char> characters = [];

            if (generateConfig.IsLowerCase)
                characters.AddRange(GetCharacters(CharType.LowerCase));

            if (generateConfig.IsUpperCase)
                characters.AddRange(GetCharacters(CharType.UpperCase));

            if (generateConfig.IsDigits)
                characters.AddRange(GetCharacters(CharType.Digits));

            if (generateConfig.IsSymbols)
                characters.AddRange(GetCharacters(CharType.Symbols));

            return characters;
        }

        /// <summary>
        /// Obtiene solo los caracteres de letra (minúsculas y/o mayúsculas) basado en la configuración.
        /// Se utiliza para aplicar la restricción de letra inicial en la contraseña.
        /// </summary>
        /// <param name="config">Objeto de configuración que especifica qué tipos de letras incluir</param>
        /// <returns>Una lista que contiene letras minúsculas y/o mayúsculas basado en la configuración</returns>
        private static List<char> GetLetterCharacters(GenerateConfig config)
        {
            List<char> letters = new List<char>();
            if (config.IsLowerCase) letters.AddRange(GetCharacters(CharType.LowerCase));
            if (config.IsUpperCase) letters.AddRange(GetCharacters(CharType.UpperCase));
            return letters;
        }

        /// <summary>
        /// Recupera el conjunto de caracteres correspondiente a un tipo de carácter específico.
        /// </summary>
        /// <param name="charType">El tipo de caracteres a recuperar</param>
        /// <returns>Una lista de caracteres para el tipo especificado:
        /// - LowerCase: a-z (26 caracteres)
        /// - UpperCase: A-Z (26 caracteres)
        /// - Digits: 0-9 (10 caracteres)
        /// - Symbols: !@#$%^&amp;*()_+-={}[]\|;:'"&lt;&gt;,.?/~` (32 caracteres)</returns>
        private static List<char> GetCharacters(CharType charType)
        {
            if (charType == CharType.LowerCase)
            {
                return Enumerable.Range('a', 'z' - 'a' + 1).Select(i => (char)i).ToList();
            }

            if (charType == CharType.UpperCase)
            {
                return Enumerable.Range('A', 'Z' - 'A' + 1).Select(i => (char)i).ToList();
            }

            if (charType == CharType.Digits)
            {
                return Enumerable.Range('0', '9' - '0' + 1).Select(c => (char)c).ToList();
            }

            return "!@#$%^&*()_+-={}[]\\|;:'\"<>,.?/~`".ToList();
        }
    }
}
