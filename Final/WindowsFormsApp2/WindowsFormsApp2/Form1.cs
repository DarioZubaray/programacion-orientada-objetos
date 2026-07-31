using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Calculadora calculadoraSumadora;

        public Form1()
        {
            InitializeComponent();
            calculadoraSumadora = new Calculadora();

            calculadoraSumadora.sumador += MiSuma;
        }

        private void MiSuma(int resultado)
        {
            MessageBox.Show($"resultado es {resultado}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num1 = 4;
            int num2 = 6;

            calculadoraSumadora.CalcularSuma(num1, num2);
        }
    }
}
