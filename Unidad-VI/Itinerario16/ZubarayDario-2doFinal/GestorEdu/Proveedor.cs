using System.ComponentModel;

namespace GestorEdu
{
    internal class Proveedor
    {
        [DisplayName("Código")]
        public string Codigo { get; set; }
        [DisplayName("Nombre")]
        public string NombreORazonSocial { get; set; }
        [DisplayName("Teléfono")]
        public string Telefono { get; set; }
        public List<Instituto> Institutos { get; set; }
        public List<Pago> Pagos { get; set; }

        public Proveedor(string pCodigo, string pNombreORazonSocial, string pTelefono)
        {
            this.Codigo = pCodigo;
            this.NombreORazonSocial = pNombreORazonSocial;
            this.Telefono = pTelefono;
            this.Institutos = new();
            this.Pagos = new();
        }

        public override string ToString()
        {
            return NombreORazonSocial;
        }
    }
}
