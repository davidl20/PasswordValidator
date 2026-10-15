using System;
using System.Security.Cryptography;

namespace PasswordValidator
{
    /// <summary>
    /// Proporciona un envoltorio para generar números aleatorios criptográficamente seguros.
    /// </summary>
    /// <remarks>
    /// Esta clase utiliza el generador de números aleatorios criptográfico del sistema para producir
    /// valores impredecibles adecuados para operaciones sensibles a la seguridad, como la generación
    /// de contraseñas y la creación de tokens.
    /// </remarks>
    public class SecureRandom
    {
        /// <summary>
        /// Genera un número entero aleatorio criptográficamente seguro entre 0 (inclusive) y
        /// el valor máximo especificado (exclusive).
        /// </summary>
        /// <param name="n">El límite superior exclusivo del número aleatorio a generar.
        /// Debe ser mayor que 0.</param>
        /// <returns>Un número entero aleatorio criptográficamente seguro que es mayor o igual
        /// a 0 y menor que <paramref name="n"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Se lanza cuando <paramref name="n"/> es menor que o igual a 0.
        /// </exception>
        /// <example>
        /// <code>
        /// var secureRandom = new SecureRandom();
        /// int numeroAleatorio = secureRandom.Next(100); // Retorna un número entre 0 y 99
        /// </code>
        /// </example>
        public int Next(int n)
        {
            if(n <= 0)
            {
                throw new ArgumentOutOfRangeException
                    (nameof(n), "El limite debe ser mayor que 0.");
            }

            return RandomNumberGenerator.GetInt32(n);
        }
    }
}
