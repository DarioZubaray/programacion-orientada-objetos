using System.ComponentModel;

namespace ActividadIntegradoraII
{
    public class SortableBindingList<T> : BindingList<T>
    {
        private bool isSorted;
        private ListSortDirection sortDirection;
        private PropertyDescriptor sortProperty;

        protected override bool SupportsSortingCore => true;
        protected override bool IsSortedCore => isSorted;
        protected override PropertyDescriptor SortPropertyCore => sortProperty;
        protected override ListSortDirection SortDirectionCore => sortDirection;

        public SortableBindingList() : base() { }

        public SortableBindingList(IList<T> listaInicial) : base(listaInicial) { }

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            var items = Items as List<T>;
            if (items != null)
            {
                items.Sort((x, y) =>
                {
                    var xValue = prop.GetValue(x);
                    var yValue = prop.GetValue(y);
                    return direction == ListSortDirection.Ascending
                        ? Comparer<object>.Default.Compare(xValue, yValue)
                        : Comparer<object>.Default.Compare(yValue, xValue);
                });

                sortProperty = prop;
                sortDirection = direction;
                isSorted = true;
                OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
            }
        }

        protected override void RemoveSortCore()
        {
            isSorted = false;
        }
    }
}