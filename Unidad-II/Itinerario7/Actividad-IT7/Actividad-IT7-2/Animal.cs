namespace Actividad_IT7_2
{
    // 1. Clase abstracta
    abstract class Animal
    {
        public string Nombre { get; set; }

        public Animal(string nombre)
        {
            Nombre = nombre;
            Console.WriteLine($"Un nuevo animal es creado bajo el apodo: {nombre}");
        }

        // 2. Método virtual
        public virtual void HacerSonido()
        {
            Console.WriteLine("El animal debe hacer un sonido.");
        }
    }
}
