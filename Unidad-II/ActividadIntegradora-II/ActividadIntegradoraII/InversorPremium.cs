namespace ActividadIntegradoraII
{
    internal class InversorPremium : Inversor
    {
        public float TotalGastadoInversorComun { get; set; }
        protected override float  PorcentajeComision => 0.005f;
        public InversorPremium(int Legajo) : base(Legajo)
        {
        }
    }
}
