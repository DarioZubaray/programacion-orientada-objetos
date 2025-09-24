namespace ActividadIntegradoraII
{
    internal class AccionAdquirida : Accion, ICloneable
    {
        public int totalAdquirida { get; set; }

        public AccionAdquirida(string codigo, string denominacion, float cotizacionActual, int cantidadEmitida)
            : base(codigo, denominacion, cotizacionActual, cantidadEmitida)
        {
        }

        public float getValorInversion()
        {
            return totalAdquirida * CotizacionActual;
        }

        public object Clone() => this.MemberwiseClone();
        public AccionAdquirida CloneTipado() => Clone() as AccionAdquirida;
    }
}
