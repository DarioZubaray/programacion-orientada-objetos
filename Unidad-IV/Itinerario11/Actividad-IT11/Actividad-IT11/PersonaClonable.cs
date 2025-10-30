namespace Actividad_IT11
{
    internal class PersonaClonable : ICloneable
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }

        // Implementación de ICloneable
        public object Clone()
        {
            // Retorna una copia superficial del objeto actual
            return this.MemberwiseClone();
        }

        // Retorna una copia tipada
        public PersonaClonable ClonarTipado => (PersonaClonable)MemberwiseClone();

        public override string ToString()
        {
            return $"{Nombre} - {Edad} años";
        }
    }
}
