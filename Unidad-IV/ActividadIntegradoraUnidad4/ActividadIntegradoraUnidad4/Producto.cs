using System.Collections;

namespace ActividadIntegradoraUnidad4
{
    internal class Producto : ICloneable, IComparer<Producto>, IEnumerable<string>
    {
        public string Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        # region IClonable
        public object Clone()
        {
            return this.MemberwiseClone(); // shallow copy
        }

        public Producto ClonTipado => (Producto) Clone();
        #endregion

        #region IComparer

        public int Compare(Producto? x, Producto? y)
        {
            if (x == null || y == null) return 0;
            return x.Precio.CompareTo(y.Precio);
        }
        #endregion

        public void Actualizar(string descripcion, string precio, string stock)
        {
            this.Descripcion = descripcion;
            this.Precio = decimal.Parse(precio);
            this.Stock = int.Parse(stock);
        }

        #region IEnumerable
        public IEnumerator<string> GetEnumerator()
        {
            string[] partes = Id.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

            // La palabra clave 'yield return' es crucial.
            // Convierte el método en un iterador, devolviendo cada parte una por una.
            foreach (string parte in partes)
            {
                yield return parte;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
