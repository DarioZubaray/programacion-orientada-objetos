using System.ComponentModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GestorEdu
{
    internal class Instituto : IComparable<Instituto>
    {
        [DisplayName("Código")]
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Teléfono")]
        public string Telefono { get; set; }
        [DisplayName("Dirección")]
        public string Direccion { get; set; }
        public List<Proveedor> Proveedores { get; set; }
        public List<Pago> Pagos { get; set; }

        public Instituto(string pCodigo, string pNombre, string pTelefono, string pDireccion)
        {
            this.Codigo = pCodigo;
            this.Nombre = pNombre;
            this.Telefono = pTelefono;
            this.Direccion = pDireccion;
            this.Proveedores = new();
            this.Pagos = new();
        }

        public override string ToString()
        {
            return Nombre;
        }

        public int CompareTo(Instituto? other)
        {
            return string.Compare(this.Nombre, other.Nombre, StringComparison.OrdinalIgnoreCase);
        }

        public void AsignarProveedor(Proveedor proveedor)
        {
            if (!Proveedores.Contains(proveedor))
            {
                Proveedores.Add(proveedor);
                proveedor.Institutos.Add(this);
            }
        }

        public void RegistrarPago(Proveedor pProveedor, decimal pImporte, DateTime pFechaVencimiento)
        {
            var pago = new PagoTransferencia
            {
                CodigoPago = Guid.NewGuid(),
                FechaVencimiento = pFechaVencimiento,
                Importe = pImporte,
                Estado = EstadoPago.Cancelado,
                FechaPago = null,
                Instituto = this,
                Proveedor = pProveedor,
            };
            Pagos.Add(pago);
            pProveedor.Pagos.Add(pago);
        }
    }
}
