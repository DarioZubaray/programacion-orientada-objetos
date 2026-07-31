namespace Actividad_IT12
{
    internal class Baul<T>
    {
        private List<T> _items = new List<T>();

        public void Guardar(T item)
        {
            _items.Add(item);
        }

        public IEnumerable<T> SacarTodos()
        {
            return _items;
        }

        public int TotalGuardados()
        {
            return _items.Count;
        }
    }
}
