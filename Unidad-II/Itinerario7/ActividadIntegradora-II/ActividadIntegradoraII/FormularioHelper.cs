using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ActividadIntegradoraII
{
    internal class FormularioHelper
    {
        private static Random random = new Random();

        #region Generador Identificador
        private static char LetraAleatoria()
        {
            return (char)random.Next('A', 'Z' + 1);
        }

        private static int NumeroAleatorio()
        {
            return random.Next(0, 10);
        }

        public static string GenerarIdentificador(string nombreEmpresa)
        {
            // Parte 1: 4 letras mayúsculas
            string parte1 = nombreEmpresa.ToUpper();
            parte1 = parte1.Length >= 4 ? parte1.Substring(0, 4) : parte1.PadRight(4, 'X');

            // Parte 2: 4 números aleatorios
            string parte2 = random.Next(1000, 10000).ToString(); // entre 1000 y 9999

            // Parte 3: letra, número, letra, número
            string parte3 = $"{LetraAleatoria()}{NumeroAleatorio()}{LetraAleatoria()}{NumeroAleatorio()}";

            return $"{parte1}-{parte2}-{parte3}";
        }
        #endregion

        #region validador Accion
        private static bool ValidarDenominacion(string denominacion)
        {
            return Regex.IsMatch(denominacion, @"^[A-Za-zÁÉÍÓÚÑáéíóúñ\s]+$") && denominacion.Trim().Length > 0;
        }

        private static bool ValidarCodigo(string codigo)
        {
            return Regex.IsMatch(codigo, @"^[A-Za-zÁÉÍÓÚÑáéíóúñ\s]+$") && codigo.Trim().Length == 4;
        }

        private static bool ValidarCotizacionActual(string cotizacionActual)
        {
            string normalizado = cotizacionActual.Replace(',', '.');

            return decimal.TryParse(normalizado, NumberStyles.Number, CultureInfo.InvariantCulture, out _);
        }

        private static bool ValidarCantidadEmitida(string cantidadEmitida)
        {
            if (int.TryParse(cantidadEmitida, out int cantidad))
            {
                return cantidad >= 1;
            }
            return false;
        }

        public static bool ValidarAccion(string denominacion, string codigo, string cotizacionActual, string cantidadEmitida)
        {
            return ValidarDenominacion(denominacion) && ValidarCodigo(codigo) && ValidarCotizacionActual(cotizacionActual) && ValidarCantidadEmitida(cantidadEmitida);
        }
        #endregion

        #region validador Inversor
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

        public static bool ValidarInversor(string nombre, string apellido, string dni)
        {
            return ValidarNombre(nombre) && ValidarApellido(apellido) && ValidarDNI(dni);
        }
        #endregion

        #region Generador Datos
        public static List<Inversor> getInversoresListMock()
        {
            List<Inversor> listaDeInversores = new List<Inversor>();
            var accionesMock = getAccionesListMock();

            listaDeInversores.Add(new InversorComun(1, "Juan", "Pérez", 12345678));
            listaDeInversores.Add(new InversorComun(2, "Maria", "Goméz", 456789123));
            listaDeInversores.Add(new InversorComun(3, "Carlos", "Gonzales", 789123456));

            return listaDeInversores;
        }

        public static List<Accion> getAccionesListMock()
        {
            List<Accion> listaDeAcciones = new List<Accion>();

            listaDeAcciones.Add(new Accion(GenerarIdentificador("HPCP"), "HiperCompu", 120, 50000));
            listaDeAcciones.Add(new Accion(GenerarIdentificador("NOVA"), "Nova", 85, 10000));
            listaDeAcciones.Add(new Accion(GenerarIdentificador("TEHG"), "TechHigh", 33, 4000));

            return listaDeAcciones;
        }
        #endregion
    }
}
