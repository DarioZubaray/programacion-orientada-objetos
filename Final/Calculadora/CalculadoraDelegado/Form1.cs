namespace CalculadoraDelegado
{
    public partial class Form1 : Form
    {
        // 1- Declaro un tipo delegado que apunta a método que retorna int y recibe dos parámetros int
        public delegate int MiDelegado(int a, int b);

        // 3- Declaro un delegado
        MiDelegado operacion;

        public Form1()
        {
            InitializeComponent();
        }

        // 2- Declaro un método compatible
        public int MiSuma(int x, int y)
        {
            return x + y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "")
                return;

            int num1 = Int32.Parse(textBox1.Text);
            int num2 = Int32.Parse(textBox2.Text);

            // 4- Asigno el metodo compatible con el delegado declarado
            operacion = MiSuma;

            // 5- Utilizo el delgado
            MessageBox.Show(operacion(num1, num2) + "");
        }
    }
}
