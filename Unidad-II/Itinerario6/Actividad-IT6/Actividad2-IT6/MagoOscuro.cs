namespace Actividad2_IT6
{
    internal sealed class MagoOscuro : Personaje
    {
        public string Pociones { get; set; }
        public MagoOscuro()
        {
            Vida = 30;
            Arma = "Bastón Mágico";
            Pociones = "Poción de Maná";
        }

        public override string MostrarEstadisticas()
        {
            return base.MostrarEstadisticas() + $"\n\tPosiones: {Pociones}";
        }
    }
}
