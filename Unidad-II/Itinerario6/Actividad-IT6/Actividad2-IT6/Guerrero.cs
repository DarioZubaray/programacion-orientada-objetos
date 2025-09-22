namespace Actividad2_IT6
{
    internal class Guerrero : Personaje
    {
        public Inventario InventarioAdicional;
        public Guerrero()
        {
            Vida = 100;
            Arma = "Espada Rústica";
            InventarioAdicional = new Inventario()
            {
                Reliquia = "Reliquia de la Esfinge",
                Materiales = " Madera"
            };
        }

        public override string MostrarEstadisticas()
        {
            return base.MostrarEstadisticas() + $"\nInventario adicional: {InventarioAdicional}";
        }

        public class Inventario
        {
            public string Reliquia { get; set; }
            public string Materiales { get; set; }

            public override string ToString()
            {
                return $"\n\tObjeto: \"{this.Reliquia}\"\n\tCrafteables: \"{this.Materiales}\"";
            }
        }
    }
}
