using System.ComponentModel.Design;

namespace CalculadoraEvento2
{
    public partial class Form1 : Form
    {

        Calculadora calc;
        public Form1()
        {
            InitializeComponent();

            calc = new Calculadora();
            // Subscribe al evento con una funcion
            calc.ResultadoEstablecido += FuncionResultado;
        }

        private void FuncionResultado(object sender, object args)
        {
            MessageBox.Show($"El resultado es {calc.Resultado}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "")
                return;

            // Convertir valores
            int num1 = int.Parse(textBox1.Text);
            int num2 = int.Parse(textBox2.Text);

            // se interactua y deja que dispare el evento
            calc.Resultado = num1 + num2;
        }
    }
}
