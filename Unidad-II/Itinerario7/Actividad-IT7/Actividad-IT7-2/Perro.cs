namespace Actividad_IT7_2
{
    // 3. Clase sellada
    sealed class Perro : Animal
    {
        public Perro(string nombre) : base(nombre)
        {
            Console.WriteLine($"Creando instancia perro: {nombre}");
        }

        // Sobrescribimos el método virtual
        public override void HacerSonido()
        {
            Console.WriteLine($"{Nombre} dice: ¡Guau!");
        }

        // 4. Clase anidada
        public class Collar
        {
            public string Color { get; set; }

            public Collar(string color)
            {
                Color = color;
            }

            public void Mostrar()
            {
                Console.WriteLine($"El collar es de color {Color}.");
            }
        }
    }
}
