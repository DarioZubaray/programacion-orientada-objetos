using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraEvento2
{
    internal class Calculadora
    {
        // declara el evento
        public event EventHandler ResultadoEstablecido;
        
        private int resultado;

        public int Resultado
        {
            get { return resultado; }
            set
            {
                resultado = value;
                // dispara el evento si hay subscritores
                ResultadoEstablecido?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
