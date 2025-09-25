using GestionMembresia.Exceptions;

namespace GestionMembresia.Entities
{
    internal class Cliente
    {
        #region Atributos
        public string NumeroSocio { get; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public Categoria Categoria { get; set; }
        public Cuota Cuota { get; set; }
        public Membresia? Membresia { get; set; }
        #endregion

        #region Contructores y Desctructores
        public Cliente(string numeroSocio, string nombre, string apellido, string dni,
                      Categoria categoria, decimal importeCuota)
        {
            // Validacion de argumentos no nulos o vacios
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) || string.IsNullOrWhiteSpace(dni))
                throw new ArgumentException("Nombre, apellido y DNI son datos obligatorios.");

            // asignacion de argumentos a atributos
            NumeroSocio = numeroSocio;
            Nombre = nombre;
            Apellido = apellido;
            DNI = dni;
            Categoria = categoria;
            Cuota = new Cuota(importeCuota);
        }
        ~Cliente()
        {
            Categoria = null;
            Cuota = null;
            Membresia = null;
        }
        #endregion

        #region Metodos
        public decimal ImporteCuota => Cuota.Importe;

        public void AsignarMembresia(Membresia membresia)
        {
            // Validacion de descuento de membresia: este importe no puede exceder el valor de la cuota del cliente.
            if (membresia.Descuento > Cuota.Importe)
                throw new MembresiaException("El descuento de la membresia no puede exceder el valor de la cuota.");

            Membresia = membresia;
        }

        public decimal CalcularCuotaFinal()
        {
            // Obteniendo poliformicamente el descuento por tipo de categoria
            decimal descuentoCategoria = Categoria.PorcentajeDescuento;
            decimal cuota = Cuota.Importe;
            cuota -= cuota * descuentoCategoria;

            // Si existe, se aplica descuento de membresia
            if (Membresia != null)
                cuota -= Membresia.Descuento;

            // Se comprueba que el valor cuota final sea positivo o cero
            return cuota > 0 ? cuota : 0;
        }
        #endregion
    }
}
