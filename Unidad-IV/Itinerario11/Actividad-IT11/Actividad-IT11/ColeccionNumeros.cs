using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_IT11
{
    internal class ColeccionNumeros : IEnumerable, IEnumerator
    {
        private int[] numeros;
        private int posicion = -1;

        public ColeccionNumeros(int[] numeros)
        {
            this.numeros = numeros;
        }

        // Implementacion IEnumerable
        public IEnumerator GetEnumerator()
        {
            posicion = -1;
            return this;
        }

        // Implementacion IEnumerator
        public object Current
        {
            get { return numeros[posicion]; }
        }

        public bool MoveNext()
        {
            posicion++;
            return (posicion < numeros.Length);
        }

        public void Reset()
        {
            posicion = -1;
        }
    }
}
