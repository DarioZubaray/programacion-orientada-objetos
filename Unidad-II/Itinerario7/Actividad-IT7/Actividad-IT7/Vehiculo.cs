namespace Actividad_IT7
{
    internal class Vehiculo
    {
        #region Atributos
        protected string Marca;
        protected string Modelo;
        protected int Anio;
        public static int TotalVehiculos;
        #endregion

        #region Constructor y Finalizador
        public Vehiculo()
        {
            Console.WriteLine("Constructor base: Vehiculo()");
            Marca = "Desconocida";
            Modelo = "Desconocido";
            Anio = DateTime.Now.Year;
            TotalVehiculos++;
        }

        public Vehiculo(string marca, string modelo, int anio)
        {
            Console.WriteLine("Constructor base: Vehiculo(marca,modelo,anio)");
            this.Marca = marca;
            this.Modelo = modelo;
            this.Anio = anio;
            TotalVehiculos++;
        }

        // Este constructor llama al constructor de 3 parametro usando 'this'
        public Vehiculo(string marca, string modelo) : this(marca, modelo, DateTime.Now.Year)
        {
            Console.WriteLine("Constructor base: Vehiculo(marca, modelo)");
        }

        ~Vehiculo()
        {
            TotalVehiculos--;
            Console.WriteLine($"Finalizador base: ~Vehiculo() - Marca: {Marca}");
        }
        #endregion

        #region Metodos
        // Metodos virtuales que puede ser sobrescritos
        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"\tVehiculo: {Marca} {Modelo} ({Anio})");
        }
        // Variante: Metodo de flecha: public virtual void MostrarInformacion() => Console.WriteLine($"Vehiculo: {Marca} {Modelo} ({Anio})");
        // Variante: Metodo de flecha: public virtual string ObtenerTipo() => "Vehiculo generico";
        public virtual string ObtenerTipo()
        {
            return "Vehiculo generico";
        }

        // Metodos que usan 'this' para devolver la instancia actual permitiendo el encadenamiento
        public Vehiculo ActualizarMarca(string nuevaMarca)
        {
            this.Marca = nuevaMarca;
            return this;
        }

        public Vehiculo ActualizarModelo(string nuevoModelo)
        {
            this.Modelo = nuevoModelo;
            return this;
        }

        public Vehiculo ActualizarAnio(int nuevoAnio)
        {
            this.Anio = nuevoAnio;
            return this;
        }
        #endregion
    }
}
