namespace Actividad_IT9
{
    /*
     * Desarrollar un programa que genera varias instancias (una cantidad importante),
     * verifique la memoria utilizada, pase el GC y vuelva a verificar el espacio de memoria.
     * Qué se observa?
     */
    internal class Program
    {
        private static void Main(string[] args)
        {
            long memoriaAntes = GC.GetTotalMemory(false);
            Console.WriteLine($"Memoria antes de crear objetos: {memoriaAntes:N0} bytes");

            // Crear muchas instancias (por ejemplo, 1 millón)
            for (int i = 0; i < 1_000_000; i++)
            {
                var obj = new byte[1024]; // de 1 KB cada uno
            }

            long memoriaDespues = GC.GetTotalMemory(false);
            Console.WriteLine($"Memoria después de crear objetos: {memoriaDespues:N0} bytes");

            // Forzar recolección de basura
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            long memoriaFinal = GC.GetTotalMemory(true);
            Console.WriteLine($"Memoria después de GC: {memoriaFinal:N0} bytes");

            Console.WriteLine("\n\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}