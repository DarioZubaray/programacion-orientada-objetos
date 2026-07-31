using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class Calculadora
    {
        public delegate void Suma(int result);

        public event Suma sumador;

        public void CalcularSuma(int a, int b)
        {
            var resultado = a + b;
            sumador.Invoke(resultado);
        }


    }
}
