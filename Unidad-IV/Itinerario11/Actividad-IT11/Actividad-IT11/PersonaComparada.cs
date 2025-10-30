using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_IT11
{
    internal class PersonaComparada
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }

        public override string ToString()
        {
            return $"{Nombre} {Apellido} - Edad: {Edad}, Altura: {Altura}m, Peso: {Peso}kg";
        }

        public class ComparadorPersona : IComparer<PersonaComparada>
        {
            private readonly int criterio;

            // Criterios de ordenamiento: 1=Nombre y Apellido, 2=Edad, 3=Altura, 4=Peso
            public ComparadorPersona(int criterio)
            {
                this.criterio = criterio;
            }

            public int Compare(PersonaComparada x, PersonaComparada y)
            {
                switch (criterio)
                {
                    case 1:
                    {
                            if(x.Nombre.Equals(y.Nombre)) return string.Compare(x.Apellido, y.Apellido);
                            return string.Compare(x.Nombre, y.Nombre);
                    }
                    case 2: return x.Edad.CompareTo(y.Edad);
                    case 3: return x.Altura.CompareTo(y.Altura);
                    case 4: return x.Peso.CompareTo(y.Peso);
                    default: return 0;
                }
            }
        }
    }
}
