using System.ComponentModel;

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

        public Instituto(string pCodigo, string pNombre, string pTelefono, string pDireccion)
        {
            this.Codigo = pCodigo;
            this.Nombre = pNombre;
            this.Telefono = pTelefono;
            this.Direccion = pDireccion;
            this.Proveedores = new List<Proveedor>();
        }

        public override string ToString()
        {
            return Nombre;
        }

        public int CompareTo(Instituto? other)
        {
            return string.Compare(this.Nombre, other.Nombre, StringComparison.OrdinalIgnoreCase);
        }
    }
}
