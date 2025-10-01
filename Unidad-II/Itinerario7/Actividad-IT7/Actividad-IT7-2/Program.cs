namespace Actividad_IT7_2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Desarrollar un programa que posea al menos una clase abstracta, un método virtual, una clase sellada y una clase anidada.");
            Console.WriteLine("========================================================================================================================\n");

            Console.WriteLine("Creando una instancia de la clase sellada Perro: new Perro(\"Firulais\")\nPila de llamadas:");
            Perro perro1 = new Perro("Firulais");

            Console.WriteLine("\nEl perro sobrescribe el metodo virtual de la clase abstracta Animal");
            perro1.HacerSonido();

            Console.WriteLine("\nCreando una instancia de la clase sellada Perro: new Perro(\"Scooby\")\nPila de llamadas:");
            Perro perro2 = new Perro("Scooby");

            Console.WriteLine("\nEl perro sobrescribe el metodo virtual de la clase abstracta Animal");
            perro2.HacerSonido();

            // Usamos la clase anidada
            Console.WriteLine("\nCreando una instancia de la clase anidada Collar: new Perro.Collar(\"Rojo\")");
            Perro.Collar collar = new Perro.Collar("Rojo");
            collar.Mostrar();

            Console.ReadKey();
        }
    }
}