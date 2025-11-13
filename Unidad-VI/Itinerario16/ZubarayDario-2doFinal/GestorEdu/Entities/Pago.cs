namespace GestorEdu.Entities
{
    internal abstract class Pago
    {
        public Guid CodigoPago { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal Importe { get; set; }
        public EstadoPago Estado { get; set; }
        public DateTime? FechaPago { get; set; }

        // Propiedad que debe ser implementada por las subclases
        public abstract decimal Recargo { get; }
        public decimal TotalAbonado => Importe + Recargo;
        public Instituto Instituto { get; set; }
        public Proveedor Proveedor { get; set; }

        // Método abstracto para lógica específica futura (Polimorfismo)
        public abstract void ProcesarPago();

        public virtual bool ValidarFechaVencida()
        {
            return FechaVencimiento < DateTime.Today;
        }
    }

    public enum EstadoPago
    {
        No_Cancelado = 0,
        Cancelado = 1,
    }

}
