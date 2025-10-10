namespace Actividad_IT10_2
{
    /*
     * Desarrollar un programa que aplique el concepto de manejo de errores.
     * Generar un error personalizado por medio de una clase que herede de Exception y disparar el error con Throw.
     */
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Ejemplo de exception personalizada");

            try
            {
                Console.Write("Ingrese su edad: ");
                int edad = int.Parse(Console.ReadLine() ?? "0");

                if (edad < 0 || edad > 120)
                {
                    throw new EdadInvalidaException($"Edad invalida: {edad}. Debe estar entre 0 y 120.");
                }

                Console.WriteLine($"Edad registrada correctamente: {edad} años.");
            }
            catch (EdadInvalidaException ex)
            {
                // Capturamos nuestra excepción personalizada
                Console.WriteLine($"[Error] personalizado: {ex.Message}");
            }
            catch (FormatException ex)
            {
                // Captura error si el usuario no ingresa un numero
                Console.WriteLine($"[Error] formato: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Captura cualquier otro error inesperado
                Console.WriteLine($"[Error] inesperado: {ex.Message}");
            }
            finally
            {
                // Bloque finally (siempre se ejecuta)
                Console.WriteLine("[Finally]  Bloque finally ejecutado (limpieza o cierre de programa).");
            }

            Console.WriteLine("Programa finalizado correctamente.");

            Console.WriteLine("\n\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}