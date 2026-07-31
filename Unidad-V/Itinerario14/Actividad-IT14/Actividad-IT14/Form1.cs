namespace Actividad_IT14
{
    public partial class Form1 : Form
    {
        List<Persona> personas;
        public Form1()
        {
            InitializeComponent();
            personas = new List<Persona>()
            {
                new Persona() { Nombre = "Ana", Edad = 29, Ciudad = "Buenos Aires"},
                new Persona() { Nombre = "Pedro", Edad = 31, Ciudad = "Buenos Aires"},
                new Persona() { Nombre = "Maria", Edad = 30, Ciudad = "Santa Fe"},
                new Persona() { Nombre = "Juan", Edad = 35, Ciudad = "Cordoba"},
                new Persona() { Nombre = "Carlos", Edad = 20, Ciudad = "Mendoza"},
                new Persona() { Nombre = "Ana Maria", Edad = 22, Ciudad = "Cordoba"},
                new Persona() { Nombre = "Mariana", Edad = 40, Ciudad = "Buenos Aires"},
                new Persona() { Nombre = "Jose", Edad = 35, Ciudad = "Jujuy"},
                new Persona() { Nombre = "Eugenio", Edad = 22, Ciudad = "Santa Fe"},
                new Persona() { Nombre = "Roberta", Edad = 33, Ciudad = "Buenos Aires"},
                new Persona() { Nombre = "Palomo", Edad = 18, Ciudad = "Cordoba"},
            };

            dataGridView1.DataSource = personas;
        }

        // Menores de 30
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            var menoresDe30 = personas.Where(p => p.Edad < 30).ToList();
            dataGridView1.DataSource = menoresDe30;
        }

        // Mayores de 30
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            var mayoresDe30 = personas.Where(p => p.Edad > 30).ToList();
            dataGridView1.DataSource = mayoresDe30;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            var exactamente30 = personas.Where(p => p.Edad == 30).ToList();
            dataGridView1.DataSource = exactamente30;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = personas;
        }
    }
}
