namespace ActividadIntegradoraII
{
    public class Accion
    {
        public string Codigo { get; set; }
        public string Denominacion { get; set; }
        public float CotizacionActual { get; set; }
        public int CantidadEmitida { get; set; }

        private int cantidadActual;

        public Accion(string codigo, string denominacion, float cotizacionActual, int cantidadEmitida)
        {
            Codigo = codigo;
            Denominacion = denominacion;
            CotizacionActual = cotizacionActual;
            CantidadEmitida = cantidadEmitida;
            cantidadActual = cantidadEmitida;
        }

        public void Comprar(int cantidadAComprar)
        {
            if (cantidadActual - cantidadAComprar < 0) throw new VentaAccionInvalidaException();

            cantidadActual -= cantidadAComprar;
        }

        public void Vender(int cantidadAVender)
        {
            cantidadActual += cantidadAVender;
        }
    }
}
