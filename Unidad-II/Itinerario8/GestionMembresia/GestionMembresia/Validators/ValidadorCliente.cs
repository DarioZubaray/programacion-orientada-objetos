using System.Globalization;
using System.Text.RegularExpressions;

namespace GestionMembresia.Validators
{
    internal class ValidadorCliente
    {
        private static bool ValidarNombre(string nombre)
        {
            // Validacion nombre contiene al menos 1 caracter alfabetico
            return Regex.IsMatch(nombre, @"^[A-Za-zÁÉÍÓÚÑáéíóúñ\s]+$") && nombre.Trim().Length > 0;
        }

        private static bool ValidarApellido(string apellido)
        {
            // Validacion apellido contenga al menos 1 caracter alfabetico
            return Regex.IsMatch(apellido, @"^[A-Za-zÁÉÍÓÚÑáéíóúñ\s]+$") && apellido.Trim().Length > 0;
        }

        private static bool ValidarDNI(string dni)
        {
            // El dni debe ser numerico y de 7 a 9 caracteres de largo
            return Regex.IsMatch(dni, @"^\d{7,9}$");
        }

        public static bool ValidarCliente(string nombre, string apellido, string dni)
        {
            return ValidarNombre(nombre) && ValidarApellido(apellido) && ValidarDNI(dni);
        }

        public static bool EsDecimalValido(string input)
        {
            // El decimal no debe ser nulo o vacio
            if (string.IsNullOrWhiteSpace(input)) return false;

            // Solo permite números con un unico separador decimal (coma o punto)
            if (!Regex.IsMatch(input.Trim(), @"^\d+([.,]\d+)?$")) return false;

            // Unificamos separador para TryParse
            string normalizado = input.Replace(',', '.');

            return decimal.TryParse(normalizado, NumberStyles.Number, CultureInfo.InvariantCulture, out _);
        }

        public static bool ValidarValorCuota(string valorCuota)
        {
            return string.IsNullOrWhiteSpace(valorCuota) || !EsDecimalValido(valorCuota);
        }
    }
}
