namespace ActividadIntegradoraII
{
    internal class InversorComun : Inversor, ICloneable
    {
        public InversorComun(int Legajo) : base(Legajo)
        {
        }

        public InversorComun(int Legajo, string Apellido, string Nombre, int DNI) : base(Legajo, Apellido, Nombre, DNI)
        {
        }

        public object Clone() => this.MemberwiseClone();
        public InversorComun CloneTipado() => Clone() as InversorComun;
    }
}
