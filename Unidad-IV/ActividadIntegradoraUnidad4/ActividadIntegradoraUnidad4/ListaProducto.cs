using System.Collections;

namespace ActividadIntegradoraUnidad4
{
    internal class ListaProducto : IEnumerable<Producto>, IEnumerator<Producto>
    {
        private List<Producto> _productos = new List<Producto>();
        private int posicion = -1;

        public int Contar() => _productos.Count;
        public List<Producto> ObtenerTodos() => _productos.ToList();
        public void Agregar(Producto p) => _productos.Add(p);
        public void Borrar(Producto p) => _productos.Remove(p);
        public Producto? EncontrarPorId(string idProducto) => _productos.SingleOrDefault(p => p.Id == idProducto);
        public int EncontrarIndice(string idProducto) => _productos.FindIndex(p => p.Id == idProducto);
        public void Modificar(Producto p, int posicion) => _productos[posicion] = p;

        public void OrdenarIdAscendente() => _productos.Sort((a, b) => a.Id.CompareTo(b.Id));
        public void OrdenarIdDescendente() => _productos.Sort((a, b) => b.Id.CompareTo(a.Id));
        public void OrdenarPrecioAscendente() => _productos.Sort((a, b) => a.Precio.CompareTo(b.Precio));
        public void OrdenarPrecioDescendente() => _productos.Sort((a, b) => b.Precio.CompareTo(a.Precio));

        #region IEnumerable
        public IEnumerator<Producto> GetEnumerator() => this;
        IEnumerator IEnumerable.GetEnumerator() => this;
        #endregion

        #region IEnumerator
        public Producto Current
        {
            get
            {
                if (posicion < 0 || posicion >= _productos.Count)
                    throw new InvalidOperationException();
                return _productos[posicion];
            }
        }
        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            posicion++;
            return (posicion < _productos.Count);
        }

        public void Reset() => posicion = -1;
        #endregion
        public void Dispose() { }
    }
}
