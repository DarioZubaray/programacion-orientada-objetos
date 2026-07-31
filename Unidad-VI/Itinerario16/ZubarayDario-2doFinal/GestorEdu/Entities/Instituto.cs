using GestorEdu.Exceptions;
using System.ComponentModel;

namespace GestorEdu.Entities
{
    internal class Instituto
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
            Codigo = pCodigo;
            Nombre = pNombre;
            Telefono = pTelefono;
            Direccion = pDireccion;
            Proveedores = new();
            Pagos = new();
        }

        public override string ToString()
        {
            return Nombre;
        }

        public void AsignarProveedor(Proveedor proveedor)
        {
            if (!Proveedores.Contains(proveedor))
            {
                Proveedores.Add(proveedor);
                proveedor.Institutos.Add(this);
            }
        }

        public void RegistrarPago(Proveedor pProveedor, string pTipoPago, decimal pImporte, DateTime pFechaVencimiento)
        {
            Pago? pago = null;
            if (pTipoPago == PagoTransferencia.TIPO)
            {
                pago = new PagoTransferencia
                {
                    CodigoPago = Guid.NewGuid(),
                    FechaVencimiento = pFechaVencimiento,
                    Importe = pImporte,
                    Estado = EstadoPago.No_Cancelado,
                    FechaPago = null,
                    Instituto = this,
                    Proveedor = pProveedor,
                };
            }
            else if (pTipoPago == PagoCheque.TIPO)
            {
                pago = new PagoCheque
                {
                    CodigoPago = Guid.NewGuid(),
                    FechaVencimiento = pFechaVencimiento,
                    Importe = pImporte,
                    Estado = EstadoPago.No_Cancelado,
                    FechaPago = null,
                    Instituto = this,
                    Proveedor = pProveedor,
                };
            }
            else
            {
                throw new PagoException("No se pudo identificar el tipo de pago a registrar.");
            }

            Pagos.Add(pago);
            pProveedor.Pagos.Add(pago);
        }
    }
}
