using System.Numerics;

namespace PasswordValidator
{
    /// <summary>
    /// MainForm es la interfaz de usuario principal de la aplicación Validador de Contraseñas.
    /// Proporciona funcionalidad para generar contraseñas con conjuntos de caracteres y restricciones personalizables,
    /// calcular entropía (combinaciones) y administrar operaciones del portapapeles.
    /// </summary>
    /// <remarks>
    /// El formulario admite las siguientes características:
    /// - Generar contraseñas con longitud configurable (mediante TrackBar)
    /// - Incluir/excluir tipos de caracteres: mayúsculas, minúsculas, dígitos y símbolos
    /// - Aplicar restricciones: debe comenzar con mayúscula, debe comenzar con cualquier letra, debe contener al menos un dígito
    /// - Calcular el total de combinaciones de contraseñas posibles según las restricciones seleccionadas
    /// - Copiar la contraseña generada al portapapeles del sistema
    /// </remarks>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase MainForm y configura todos los componentes del formulario.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Maneja el evento de desplazamiento de la barra de desplazamiento para actualizar el valor de longitud de contraseña mostrado.
        /// </summary>
        /// <param name="sender">El control TrackBar que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento (no utilizados).</param>
        /// <remarks>
        /// Este método actualiza el texto de la etiqueta lblLength para reflejar el valor actual de TrackBarLength
        /// cada vez que el usuario ajusta el control deslizante de longitud de contraseña.
        /// </remarks>
        private void TrackBarScroll(object sender, EventArgs e)
        {
            lblLength.Text = TrackBarLength.Value.ToString();
        }

        /// <summary>
        /// Construye un objeto <see cref="GenerateConfig"/> a partir del estado actual de los controles del formulario.
        /// </summary>
        /// <returns>La configuración de generación que refleja las selecciones del usuario.</returns>
        private GenerateConfig BuildConfig()
        {
            return new GenerateConfig
            {
                Length = TrackBarLength.Value,
                IsLowerCase = CheckBoxLowerCase.Checked,
                IsUpperCase = CheckBoxUpperCase.Checked,
                IsDigits = CheckBoxDigits.Checked,
                IsSymbols = CheckBoxSymbols.Checked,
                MustStartWithUpperCase = CheckBoxMustStartWithUpper.Checked,
                MustStartWithLetter = CheckBoxMustStartWithLetter.Checked,
                MustContainAtLeastOneDigit = CheckBoxMustContainDigit.Checked
            };
        }

        /// <summary>
        /// Genera una contraseña basada en los conjuntos de caracteres y restricciones seleccionados por el usuario.
        /// </summary>
        /// <param name="sender">El botón Generar que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento (no utilizados).</param>
        /// <remarks>
        /// Valida la configuración y delega la generación en <see cref="PasswordGenHelper.GeneratePassword"/>,
        /// que usa <see cref="SecureRandom"/> (aleatoriedad criptográficamente segura). La generación aplica:
        /// 1. La restricción de la primera posición (mayúscula inicial tiene prioridad sobre letra inicial; en su
        ///    defecto, cualquier carácter del alfabeto).
        /// 2. El alfabeto completo para las posiciones restantes.
        /// 3. El requisito de al menos un dígito, si está activado.
        ///
        /// Muestra cuadros de diálogo de advertencia si:
        /// - No se selecciona ningún tipo de carácter
        /// - Las restricciones de inicio no se pueden satisfacer (por ejemplo, "Start with Upper" está marcado pero mayúsculas está deshabilitado)
        /// </remarks>
        private void BtnGenerateClick(object sender, EventArgs e)
        {
            GenerateConfig config = BuildConfig();

            if (!config.IsLowerCase && !config.IsUpperCase && !config.IsDigits && !config.IsSymbols)
            {
                MessageBox.Show("Debes seleccionar al menos un tipo de carácter.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que la regla de inicio sea ejecutable
            bool startImpossible =
                (config.MustStartWithUpperCase && !config.IsUpperCase) ||
                (config.MustStartWithLetter && !config.MustStartWithUpperCase && !config.IsLowerCase && !config.IsUpperCase);

            if (startImpossible)
            {
                MessageBox.Show("No se puede cumplir la regla de inicio porque el grupo de caracteres requerido está desactivado.", "Error de Configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string password = PasswordGenHelper.GeneratePassword(config);

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("No se pudo generar la contraseña con la configuración actual.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtPassword.Text = password;
        }

        /// <summary>
        /// Copia la contraseña generada del campo de texto al portapapeles del sistema.
        /// </summary>
        /// <param name="sender">El botón Copiar que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento (no utilizados).</param>
        /// <remarks>
        /// Este método solo copia al portapapeles si el campo de texto de contraseña no está vacío.
        /// La contraseña está disponible para pegarse en otras aplicaciones.
        /// </remarks>
        private void BtnCopyClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Text))
            {
                Clipboard.SetText(txtPassword.Text);
            }
        }

        /// <summary>
        /// Calcula el número total de combinaciones de contraseña posibles basadas en la configuración actual.
        /// </summary>
        /// <param name="sender">El botón Calcular que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento (no utilizados).</param>
        /// <remarks>
        /// Delega el cálculo en <see cref="PasswordGenHelper.CalculateTotalCombinations"/>, que emplea
        /// <see cref="BigInteger"/> (precisión arbitraria) para evitar el desbordamiento en longitudes grandes.
        /// El cálculo se realiza por conteo combinatorio (sin generar contraseñas):
        /// 1. Determina el alfabeto efectivo según los tipos de carácter activos.
        /// 2. Determina las opciones de la primera posición según las restricciones de inicio.
        /// 3. Aplica la fórmula:
        ///    - Sin requisito de dígito: firstCharOptions × totalSet^(length-1)
        ///    - Con requisito de dígito: (Todas las combinaciones posibles) - (Combinaciones sin dígitos)
        ///
        /// Muestra "0" combinaciones si la configuración es inválida (sin tipos de carácter, restricción de
        /// inicio imposible, o requisito de dígito con los dígitos deshabilitados).
        /// </remarks>
        private void BtnCalculateClick(object sender, EventArgs e)
        {
            GenerateConfig config = BuildConfig();
            BigInteger totalCombinations = PasswordGenHelper.CalculateTotalCombinations(config);

            lblCombinationsResult.Text = $"Total de combinaciones: {totalCombinations:N0}";
        }
    }
}