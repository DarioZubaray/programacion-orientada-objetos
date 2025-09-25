using System.Globalization;

namespace GestionMembresia.Helpers
{
    internal class FormularioHelper
    {
        private int idsClientesUtilizados = 0;
        private HashSet<string> idsMembresiasUtilizados = new HashSet<string>();

        // Se actualiza la grilla por referencia con el valor del parametro
        internal void ActualizarGrilla<T>(DataGridView pDGV, List<T> pO)
        {
            if (pO == null) return;
            pDGV.DataSource = null;
            pDGV.DataSource = pO;
        }

        internal string GenerarIdSocio()
        {
            return (++idsClientesUtilizados).ToString();
        }

        // Retorna cero de no poder hacer la convercion
        public static decimal ConvertirADecimal(string input)
        {
            // El decimal a convertir no debe ser nulo o vacio
            if (string.IsNullOrWhiteSpace(input)) return 0;

            // Se reemplaza la coma por el punto para la separacion de decimales
            string normalizado = input.Replace(',', '.');

            // Se realiza la convercion
            if (decimal.TryParse(normalizado, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal resultado))
                return resultado;

            return 0;
        }

        private string GenerarIdMembresia()
        {
            var random = new Random();
            string letras = new string(Enumerable.Range(0, 2)
                .Select(_ => (char)random.Next(65, 91 + 26)) // A-Z (65–90) y a-z (97–122)
                .Select(c => char.IsUpper(c) ? c : (char)random.Next(97, 123)) // mezcla mayusculas y minusculas
                .ToArray());

            string digitos = random.Next(0, 100).ToString("D2"); // dos digitos

            return letras + digitos;
        }

        internal string GenerarIdUnicoMembresias()
        {
            // Generar un nuevo Id hasta que se puedo incluir en el set que no admite repetidos
            string nuevoId;
            do
            {
                nuevoId = GenerarIdMembresia();
            } while (idsMembresiasUtilizados.Contains(nuevoId));

            idsMembresiasUtilizados.Add(nuevoId);
            return nuevoId;
        }

    }
}
