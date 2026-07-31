using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraEvento
{
    internal class Calculadora
    {
        // Definimos el delegado del evento
        public delegate void OperacionRealizadaEventHandler(int resultado);

        // Declaramos el evento basado en el delegado
        public event OperacionRealizadaEventHandler OperacionRealizada;

        public void Sumar(int a, int b)
        {
            int r = a + b;

            // Disparamos el evento si hay suscriptores
            OperacionRealizada?.Invoke(r);
        }
    }
}
