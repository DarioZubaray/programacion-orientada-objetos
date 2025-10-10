using System.Net;

namespace Actividad_IT_10
{
    /*
     * Desarrollar un programa que aplique el concepto de manejo de errores.
     * La estructura propuesta debe tener al menos 5 Catch y el finally.
     */
    internal class Program
    {
        // 1 Division por cero
        static void DividirPorCero()
        {
            Console.WriteLine("Intentando dividir diez por cero...");
            try
            {
                int a = 10, b = 0;
                int resultado = a / b;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"[Program] Error matemático: {ex.Message}");
                Console.WriteLine();
            }
        }

        // 2 Acceso fuera de rango
        static void FueraDeRango()
        {
            Console.WriteLine("Intentando acceder al indice 5 de un array de 3 posiciones...");
            try
            {
                int[] numeros = { 1, 2, 3 };
                Console.WriteLine(numeros[5]);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"[Program]  Error de índice: {ex.Message}");
                Console.WriteLine();
            }
        }
        // 3 Archivo inexistente
        static void ArchivoInexistente()
        {
            Console.WriteLine("Intentando acceder a 'archivo_inexistente.txt'");
            try
            {
                string contenido = File.ReadAllText("archivo_inexistente.txt");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"[Program] Archivo no encontrado: {ex.Message}");
                Console.WriteLine();
            }
        }

        // 4 Conversion invalida
        static void ConversionInvalida()
        {
            Console.WriteLine("Intentando convertir 'abc' en un numero...");
            try
            {
                int valor = int.Parse("abc");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"[Program] Error de formato: {ex.Message}");
                Console.WriteLine();
            }
        }

        // 5 Peticion web fallida
        static void PeticionWebInvalida()
        {
            Console.WriteLine("Intentando acceder a 'http://direccion-no-valida.com'...");
            try
            {
                var cliente = new WebClient();
                string data = cliente.DownloadString("http://direccion-no-valida.com");
            }
            catch (WebException ex)
            {
                Console.WriteLine($"[Program] Error de conexión web: {ex.Message}");
                Console.WriteLine();
            }
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Ejemplo de manejo de errores con múltiples catch");
            Console.WriteLine("Intentando ejecutar operaciones...");
            Console.WriteLine();

            try
            {
                DividirPorCero();
                Thread.Sleep(1000);
                FueraDeRango();
                Thread.Sleep(1000);
                ArchivoInexistente();
                Thread.Sleep(1000);
                ConversionInvalida();
                Thread.Sleep(1000);
                PeticionWebInvalida();
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                // Captura general — siempre al final
                Console.WriteLine($"[Program] Error inesperado: {ex.GetType().Name} - {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Bloque finally ejecutado — limpieza de recursos o mensajes finales.");
            }

            Console.WriteLine("El programa continúa su ejecución normalmente.");
            Console.WriteLine("\n\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}