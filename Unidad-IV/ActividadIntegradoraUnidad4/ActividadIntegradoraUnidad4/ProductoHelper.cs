using System.Text.RegularExpressions;

namespace ActividadIntegradoraUnidad4
{

    public class ProductoHelper
    {
        public const string NUMERO_LINEA = "Número de Línea";
        public const string FECHA_FABRICACION = "Fecha de Fabricación";
        public const string DESCRIPCION = "Descripción";
        public const string PRECIO = "Precio";
        public const string STOCK = "Stock";

        /*
         * "001-L01-OP200-02/10/2018" 
         * Dónde:
         *               001  Es el código de producto 
         *               L01  Número de línea 
         *             OP200  Código de operador 
         *        01/10/2018  Fecha de fabricación 
         */
        public static bool ValidarId(string id)
        {
            // Patrón: 3 dígitos - 1 letra + 2 dígitos - 2 letras + 3 dígitos - fecha dd/MM/yyyy
            string patron = @"^[A-Za-z0-9]{3,}-[A-Za-z0-9]{2,}-[A-Za-z0-9]{2,}-\d{2}/\d{2}/\d{4}$";
            return !Regex.IsMatch(id, patron);
        }

        public static string GenerarId(string codigoProducto, string numeroLinea, string codigoOperador, string fechaFabricacion)
        {
            if (string.IsNullOrWhiteSpace(codigoProducto) ||
                string.IsNullOrWhiteSpace(numeroLinea) ||
                string.IsNullOrWhiteSpace(codigoOperador) ||
                string.IsNullOrWhiteSpace(fechaFabricacion))
                throw new ArgumentException("Ninguno de los parámetros puede estar vacío.");

            string id = $"{codigoProducto}-{numeroLinea}-{codigoOperador}-{fechaFabricacion}";
            if (ValidarId(id))
                throw new Exception("Ocurrió un error imprevisto en la generación del id");

            return id;
        }

        public static string ModificarIdClonado(string id)
        {
            string[] partes = id.Split('-');
            if (partes.Length != 4)
                throw new FormatException("El ID no tiene el formato esperado: [Producto]-[Linea]-[Operador]-[Fecha]");

            string operador = partes[2];
            if (string.IsNullOrEmpty(operador))
                throw new ArgumentException("El código de operador está vacío.");

            char primera = operador[0];

            char siguiente = ObtenerSiguienteLetra(primera);

            string nuevoOperador = siguiente + operador.Substring(1);
            partes[2] = nuevoOperador;

            return string.Join("-", partes);
        }

        private static char ObtenerSiguienteLetra(char c)
        {
            c = char.ToUpper(c);

            if (c < 'A' || c > 'Z')
                throw new InvalidOperationException($"El carácter '{c}' no es una letra válida.");

            char siguiente = (char)(c + 1);

            if (siguiente == 'O')
                siguiente = (char)(siguiente + 1);

            if (siguiente > 'Z')
                throw new InvalidOperationException("No hay siguiente letra válida para reemplazar.");

            return siguiente;
        }

        public static void ValidarEntrada(string clave, string entrada)
        {
            if(string.IsNullOrWhiteSpace(entrada))
                throw new ArgumentException($"El valor {clave} NO puede estar vacío.");

            switch (clave)
            {
                case NUMERO_LINEA:
                    var temp0 = 0;
                    if(entrada.Length != 3 || !int.TryParse(entrada.Substring(1, 2), out temp0))
                        throw new ArgumentException($"El formato de {clave} debe ser de 2 caracteres máximo.");
                    break;

                case FECHA_FABRICACION:
                    if(!DateTime.TryParse(entrada, out var fechaObjeto))
                        throw new ArgumentException($"El valor {clave} NO posee un formato de fecha.");
                    break;

                case DESCRIPCION:
                    break;

                case STOCK:
                    int temp1 = 0;
                    if(!int.TryParse(entrada, out temp1))
                        throw new ArgumentException($"El valor {clave} NO posee un formato númerico entero.");
                    break;

                case PRECIO:
                    decimal temp2 = 0;
                    if (!decimal.TryParse(entrada, out temp2))
                        throw new ArgumentException($"El valor {clave} NO posee un formato númerico decimal.");
                    break;

                default:
                    break;
            }
            ;
        }
    }
}
