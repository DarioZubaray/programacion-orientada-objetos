namespace Actividad1_IT6
{
    internal class Automovil : Vehiculo
    {
        #region Atributos
        private int numeroPuertas;
        private string tipoTransmision;
        #endregion

        #region Constructores
        // Constructor que llama al constructor base sin parámetros
        public Automovil() : base()
        {
            Console.WriteLine("Constructor por defecto de Automovil llamado");
            this.numeroPuertas = 4;
            this.tipoTransmision = "Manual";
        }

        // Constructor que llama al constructor base con parámetros
        public Automovil(string marca, string modelo, int año, int puertas, string transmision)
            : base(marca, modelo, año) // Llamada explícita al constructor base
        {
            Console.WriteLine($"Constructor parametrizado de Automovil llamado");
            this.numeroPuertas = puertas;
            this.tipoTransmision = transmision;
        }

        // Constructor que encadena con otro constructor de la clase derivada
        public Automovil(string marca, string modelo, int puertas)
            : this(marca, modelo, DateTime.Now.Year, puertas, "Automática") // Llamada a otro constructor de la misma clase
        {
            Console.WriteLine("Constructor con encadenamiento 'this' en Automovil");
        }
        #endregion

        #region Finalizadores
        // Finalizador que llama al finalizador base
        ~Automovil()
        {
            Console.WriteLine($"Finalizador de Automovil ejecutado para {marca} {modelo}");
            // El finalizador base se llama automáticamente después de este
        }
        #endregion

        #region Metodos
        // Sobrescribe el método de la clase base
        public override void MostrarInformacion()
        {
            // Llama al método de la clase base usando 'base'
            base.MostrarInformacion();
            Console.WriteLine($"Puertas: {this.numeroPuertas}, Transmisión: {this.tipoTransmision}");
        }

        // Método que sobrescribe el método protegido de la base
        protected override void IniciarMotor()
        {
            // Primero ejecuta la lógica de la clase base
            base.IniciarMotor();
            // Luego agrega comportamiento específico
            Console.WriteLine("Revisando sistemas del automóvil...");
            Console.WriteLine("Automóvil listo para conducir!");
        }

        // Método específico de Automovil que usa IniciarMotor
        public void EncenderAutomovil()
        {
            Console.WriteLine("\nEncendiendo automóvil...");
            this.IniciarMotor(); // 'this' es opcional, pero clarifica que llamamos al método de esta instancia
        }

        // Método que demuestra el uso de 'this' como parámetro
        public void CompararCon(Automovil otro)
        {
            if (otro == this) // 'this' se refiere a la instancia actual
            {
                Console.WriteLine("Estás comparando el automóvil consigo mismo!");
                return;
            }

            Console.WriteLine($"\nComparando automóviles:");
            Console.WriteLine($"   Este auto: {this.marca} {this.modelo}");
            Console.WriteLine($"   Otro auto: {otro.marca} {otro.modelo}");
        }
        #endregion
    }
}
