using GestionMembresia.Exceptions;

namespace GestionMembresia.Entities
{
    internal class Membresia : ICloneable
    {
        public string CodigoUnido { get; }
        public DateTime FechaInicio { get; }
        public decimal Descuento { get; set; }

        public Membresia(string codigoPrefijo, decimal descuento)
        {
            // Validacion del codigo, no puede ser vacio o nulo y debe ser exactamente  de 4 caracteres de largo
            if (string.IsNullOrEmpty(codigoPrefijo) && codigoPrefijo.Length != 4)
                throw new MembresiaException("La longitud del prefijo del codigo no puede estar vacia o ser diferente de 4 digitos de largo.");

            // Validar que el descuento no sea cero o negativo
            if (descuento < 0)
                throw new MembresiaException("El descuento no puede ser menor o igual a cero.");

            // Asignacion de atributos
            FechaInicio = DateTime.Now;
            CodigoUnido = $"{codigoPrefijo}_{FechaInicio.ToString("dd/MM/yyyy")}";
            Descuento = descuento;
        }

        ~Membresia()
        {
            // No hay recursos administrados ni colecciones estaticas que limpiar
        }

        public object Clone() => this.MemberwiseClone();
        public Membresia CloneTipado => Clone() as Membresia;
    }
}
