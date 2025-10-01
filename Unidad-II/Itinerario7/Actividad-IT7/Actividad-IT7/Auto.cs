namespace Actividad_IT7
{
    internal class Auto : Vehiculo
    {
        #region Atributos
        private int NumeroPuertas;
        private string TipoCombustible;
        #endregion

        #region Constructores y Finalizadores
        // Constructor que llama al constructor base usando 'base'
        public Auto(string marca, string modelo, int anio, int puertas)
            : base(marca, modelo, anio)  // Llama al constructor de la clase base
        {
            Console.WriteLine("Constructor derivado: Auto(marca,modelo,anio,puertas) [4 parametros]");
            this.NumeroPuertas = puertas;
            this.TipoCombustible = "Nafta";
        }

        // Constructor con mas parametros - usado con llamada a 'this'
        public Auto(string marca, string modelo, int año, int puertas, string combustible)
            : this(marca, modelo, año, puertas)  // Llama a constructor de 3 parametros de esta clase
        {
            Console.WriteLine("Constructor derivado: Autom(marca,modelo,anio,puertas,combustible) [completo]");
            this.TipoCombustible = combustible;
        }

        // Finalizador que llama implicitamente al finalizador base
        ~Auto()
        {
            Console.WriteLine($"Finalizador derivado: ~Auto() - Modelo: {Modelo}");
            // No es necesario llamar a ~Vehiculo()
            // El finalizador base se llama automaticamente despues de este
        }
        #endregion

        #region Metodos
        // Sobrescribe metodo de la clase base
        public override void MostrarInformacion()
        {
            // Llama al metodo de la clase base usando 'base'
            base.MostrarInformacion();
            Console.WriteLine($"\tTipo: {this.ObtenerTipo()}");
            Console.WriteLine($"\tPuertas: {NumeroPuertas}, Combustible: {TipoCombustible}");
        }

        public override string ObtenerTipo()
        {
            // Puede usar 'base' para acceder a la implementacion base
            string tipoBase = base.ObtenerTipo();
            return "Auto (hereda de " + tipoBase + ")";
        }

        public Auto ActualizarNumeroPuertas(int numeroPuertas)
        {
            this.NumeroPuertas = numeroPuertas;
            return this;
        }

        public Auto ActualizarTipoCombustible(string tipoCombustible)
        {
            this.TipoCombustible = tipoCombustible;
            return this;
        }
        #endregion
    }
}
