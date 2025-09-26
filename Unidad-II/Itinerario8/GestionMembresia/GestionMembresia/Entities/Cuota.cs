namespace GestionMembresia.Entities
{
    internal class Cuota
    {
        public decimal ImporteOriginal { get; set; }
        public decimal ValorConDescuento { get; set; }

        public Cuota(decimal importeOriginal, decimal valorConDescuento)
        {
            // Validacion para que el importe no sea negativo
            if (importeOriginal <= 0)
                throw new ArgumentException("El importe de la cuota debe ser mayor a 0.");

            // Validacion para que el descuento no supere al original
            if (importeOriginal <= 0)
                throw new ArgumentException("El importe a descontar no debe ser mayor que el importe original.");

            ImporteOriginal = importeOriginal;
            ValorConDescuento = valorConDescuento;
        }

        ~Cuota()
        {
            // No hay recursos administrados ni colecciones estaticas que limpiar
        }
    }
}
