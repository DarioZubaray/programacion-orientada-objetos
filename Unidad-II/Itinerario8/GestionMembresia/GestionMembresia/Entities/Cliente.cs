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
            // La cuota se calcula como el % de 100 - descuento
            Cuota = new Cuota(importeCuota, importeCuota * (1 - categoria.PorcentajeDescuento));
        }
 
        ~Cliente()
        {
            Categoria = null;
            Cuota = null;
            Membresia = null;
        }
        #endregion

        #region Metodos
        public decimal ImporteCuota => Cuota.ValorConDescuento;
        private decimal CuotaConDescuentoPorCategoria => Cuota.ImporteOriginal * (1 - Categoria.PorcentajeDescuento);

        public void AsignarMembresia(Membresia membresia)
        {
            // Se desasigna la membresia
            if(membresia == null)
            {
                Membresia = null;
                Cuota.ValorConDescuento = CuotaConDescuentoPorCategoria;
                return;
            }

            // Validacion de descuento de membresia: este importe no puede exceder el valor de la cuota del cliente.
            if (membresia.Descuento >= CuotaConDescuentoPorCategoria)
                throw new MembresiaException("El descuento de la membresia no puede exceder o alcanzar el total del valor de la cuota.");

            Membresia = membresia;
            Cuota.ValorConDescuento = CalcularCuotaFinal();
        }

        public decimal CalcularCuotaFinal()
        {
            // Obteniendo poliformicamente el descuento por tipo de categoria
            decimal cuota = CuotaConDescuentoPorCategoria;

            // Si existe, se aplica descuento de membresia
            if (Membresia != null)
                cuota -= Membresia.Descuento;

            // Se comprueba que el valor cuota final sea positivo o cero
            return cuota > 0 ? cuota : 0;
        }
        #endregion
    }
}
