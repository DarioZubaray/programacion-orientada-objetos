using System.ComponentModel;

namespace GestorEdu.Entities
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
            Codigo = pCodigo;
            NombreORazonSocial = pNombreORazonSocial;
            Telefono = pTelefono;
            Institutos = new();
            Pagos = new();
        }

        public override string ToString()
        {
            return NombreORazonSocial;
        }
    }
}
