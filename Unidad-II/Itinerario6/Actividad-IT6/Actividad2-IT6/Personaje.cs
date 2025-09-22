namespace Actividad2_IT6
{
    internal class Personaje
    {
        public int Vida { get; set; }
        public string Arma { get; set; }

        public virtual string MostrarEstadisticas()
        {
            return $"Salud: {Vida}, Arma: {Arma}";
        }
    }
}
