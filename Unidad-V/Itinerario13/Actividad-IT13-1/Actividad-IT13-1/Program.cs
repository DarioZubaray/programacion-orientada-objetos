namespace Actividad_IT12
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Desarrollar un programa que aplique el concepto genéricos a nivel de clase y en al menos dos métodos.\n\n");
            Baul<string> miBaul = new Baul<string>();

            miBaul.Guardar("Hola");
            miBaul.Guardar("Mundo");
            miBaul.Guardar("Cruel");

            foreach (var objeto in miBaul.SacarTodos())
            {
                Console.WriteLine($"obteniendo: \"{objeto}\"\n");
            }

            Console.ReadLine();
        }
    }
}