namespace Actividad_IT11
{
    internal class Persona : IComparable<Persona>
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }

        // Implementación de IComparable
        public int CompareTo(Persona otra)
        {
            if (otra == null) return 1;
            // Ordenar por edad de menor a mayor
            return this.Edad.CompareTo(otra.Edad);
        }
        // Sobreescribiendo como se muestra el objeto Persona
        public override string ToString()
        {
            return $"{Nombre} - {Edad} años";
        }
    }
}
