namespace CalculadoraEvento
{
    public partial class Form1 : Form
    {
        private Calculadora calc = new Calculadora();

        public Form1()
        {
            InitializeComponent();

            // Nos suscribimos al evento
            calc.OperacionRealizada += MiSuma;
        }

        // Método que se ejecuta cuando el evento se dispara
        private void MiSuma(int resultado)
        {
            MessageBox.Show($"Resultado: {resultado}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "")
                return;
            // Convertir valores
            int num1 = int.Parse(textBox1.Text);
            int num2 = int.Parse(textBox2.Text);

            // Llamamos a la suma, esto dispara el evento
            calc.Sumar(num1, num2);
        }
    }
}
