using System.Text.RegularExpressions;

namespace GestionMembresia.Validators
{
    internal class ValidadorCliente
    {
        private static bool ValidarNombre(string nombre)
        {
            return Regex.IsMatch(nombre, @"^[A-Za-zÁÉÍÓÚÑáéíóúñ\s]+$") && nombre.Trim().Length > 0;
        }

        private static bool ValidarApellido(string apellido)
        {
            return Regex.IsMatch(apellido, @"^[A-Za-zÁÉÍÓÚÑáéíóúñ\s]+$") && apellido.Trim().Length > 0;
        }

        private static bool ValidarDNI(string dni)
        {
            return Regex.IsMatch(dni, @"^\d{7,9}$");
        }

        public static bool ValidarCliente(string nombre, string apellido, string dni)
        {
            return ValidarNombre(nombre) && ValidarApellido(apellido) && ValidarDNI(dni);
        }
    }
}
