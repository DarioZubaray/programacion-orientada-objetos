namespace GestionMembresia.Entities
{
    internal class Cuota
    {
        public decimal Importe { get; set; }

        public Cuota(decimal importe)
        {
            if (importe <= 0)
                throw new ArgumentException("El importe de la cuota debe ser mayor a 0.");
 
            Importe = importe;
        }

        ~Cuota()
        {
            // No hay recursos administrados ni colecciones estáticas que limpiar
        }
    }
}
