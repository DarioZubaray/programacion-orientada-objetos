namespace Actividad1_IT6
{
    internal class Vehiculo
    {
        #region Atributos
        protected string marca;
        protected string modelo;
        protected int año;
        protected static int contadorVehiculos = 0;
        #endregion

        #region Constructores
        // Constructor por defecto
        public Vehiculo()
        {
            Console.WriteLine("Constructor por defecto de Vehiculo llamado");
            this.marca = "Sin marca";
            this.modelo = "Sin modelo";
            this.año = DateTime.Now.Year;
            contadorVehiculos++;
        }

        // Constructor parametrizado
        public Vehiculo(string marca, string modelo, int año)
        {
            Console.WriteLine($"Constructor parametrizado de Vehiculo llamado: {marca} {modelo}");
            this.marca = marca;
            this.modelo = modelo;
            this.año = año;
            contadorVehiculos++;
        }

        // Constructor que encadena con otro constructor de la misma clase
        public Vehiculo(string marca, string modelo) : this(marca, modelo, DateTime.Now.Year)
        {
            Console.WriteLine("Constructor con encadenamiento 'this' en Vehiculo");
        }
        #endregion

        #region Finalizadores
        // Finalizador de la clase base
        ~Vehiculo()
        {
            Console.WriteLine($"Finalizador de Vehiculo ejecutado para {marca} {modelo}");
            contadorVehiculos--;
        }
        #endregion

        #region Metodos
        // Método virtual que puede ser sobrescrito
        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Vehículo: {this.marca} {this.modelo} ({this.año})");
        }

        // Método que será usado por las clases derivadas
        protected virtual void IniciarMotor()
        {
            Console.WriteLine("Iniciando motor del vehículo base...");
        }

        // Método que demuestra el uso de 'this' para devolver la instancia actual
        public Vehiculo ActualizarAño(int nuevoAño)
        {
            this.año = nuevoAño;
            Console.WriteLine($"Año actualizado a {nuevoAño}");
            return this; // Permite encadenamiento de métodos
        }

        public static int ObtenerContadorVehiculos()
        {
            return contadorVehiculos;
        }
        #endregion
    }
}
