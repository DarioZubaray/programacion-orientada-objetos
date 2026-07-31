using System.ComponentModel;

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
        public Instituto? Instituto { get; set; }
        public Proveedor? Proveedor { get; set; }

        public virtual decimal TotalAbonado()
        {
            if (FechaVencimiento < DateTime.Today)
            {
                return Importe + Recargo;
            }
            return Importe;
        }

        public virtual void ProcesarPago()
        {
            FechaPago = DateTime.Now;

            if (TotalAbonado() > 15000m)
            {
                // Desencadenar evento de aviso
                MessageBox.Show("El importe ha superado el techo de $15.000,00.-", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }

    public enum EstadoPago
    {
        No_Cancelado = 0,
        Cancelado = 1,
    }

}
