using System.ComponentModel;

namespace GestorEdu.Entities
{
    internal class PagosView
    {
        [Browsable(false)]
        public string InstitutoCodigo { get; set; }
        public string InstitutoNombre { get; set; }
        [Browsable(false)]
        public string ProveedorCodigo { get; set; }
        public string ProveedorNombre { get; set; }
        public string TipoPago { get; set; }
        public string Importe { get; set; }
        public string FechaVencimiento { get; set; }
    }
}
