namespace Actividad_IT9_2
{
    /*
     * Desarrollar un programa que genere una instancia, pierda la referencia a la misma 
     * y aplicando la técnica de “resurrección de objetos” logre obtener la referencia a ese mismo objeto.
     */
    internal class Program
    {
        static void CrearYPerderReferencia()
        {
            var numeroAleatorio = new Random().Next(100);
            // Crear una instancia y luego perder la referencia
            ObjetoResucitable obj = new ObjetoResucitable(numeroAleatorio);
            Console.WriteLine($"Objeto creado con valor: {obj.Valor}");
        } // <- al salir de este método, no hay referencias

        private static void Main(string[] args)
        {
            // Por cuestiones de optimizacion el JIT mantenia la referencia y no se ejecutaba el GC
            // ObjetoResucitable obj = new ObjetoResucitable(42);
            // obj = null; // <- no se desreferencia
            CrearYPerderReferencia();

            // Forzar recolección
            GC.Collect();
            GC.WaitForPendingFinalizers();

            // Si el objeto fue resucitado, la referencia está en la variable estática
            if (ObjetoResucitable.InstanciaResucitada != null)
            {
                Console.WriteLine($"Objeto resucitado con valor: {ObjetoResucitable.InstanciaResucitada.Valor}");
            }
            else
            {
                Console.WriteLine("El objeto fue recolectado definitivamente.");
            }

            // Eliminar referencia resucitada y recolectar nuevamente
            ObjetoResucitable.InstanciaResucitada = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("Fin del programa (objeto destruido definitivamente).");

            Console.WriteLine("\n\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}