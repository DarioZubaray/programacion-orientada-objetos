namespace GestionMembresia.Entities
{
    internal class Membresia
    {
        public string CodigoUnido { get; }
        public DateTime FechaInicio { get; }
        public decimal Descuento { get; }

        public Membresia(string codigoPrefijo, decimal descuento)
        {
            // Validacion del codigo, no puede ser vacio o nulo y debe ser exactamente  de 4 caracteres de largo
            if (string.IsNullOrEmpty(codigoPrefijo) && codigoPrefijo.Length != 4)
                throw new ArgumentException("La longitud del prefijo del codigo no puede estar vacia o ser diferente de 4 digitos de largo.");

            // Asignacion de atributos
            FechaInicio = DateTime.Now;
            CodigoUnido = $"{codigoPrefijo}_{FechaInicio.ToString("dd/MM/yyyy")}";
            Descuento = descuento;
        }

        ~Membresia()
        {
            // No hay recursos administrados ni colecciones estáticas que limpiar
        }
    }
}
