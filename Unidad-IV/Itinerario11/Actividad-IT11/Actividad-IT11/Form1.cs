using static Actividad_IT11.PersonaComparada;

namespace Actividad_IT11
{
    public partial class Form1 : Form
    {
        List<Persona> personas;
        List<PersonaComparada> personasComparadas;
        PersonaClonable personaOriginal;
        List<PersonaClonable> personaClonadas;
        public Form1()
        {
            InitializeComponent();
            personas = new List<Persona> {
                new Persona { Nombre = "Ana", Edad = 30 },
                new Persona { Nombre = "Maria", Edad = 33 },
                new Persona { Nombre = "Jose", Edad = 35 },
                new Persona { Nombre = "Luis", Edad = 25 },
                new Persona { Nombre = "Carlos", Edad = 35 }
            };
            dataGridView1.DataSource = personas;

            personasComparadas = new List<PersonaComparada>
            {
                new PersonaComparada { Nombre="Ana", Apellido="López", Edad=28, Altura=1.65, Peso=60 },
                new PersonaComparada { Nombre="Maria", Apellido="Martínez", Edad=33, Altura=1.60, Peso=95 },
                new PersonaComparada { Nombre="Luis", Apellido="Martínez", Edad=35, Altura=1.80, Peso=85 },
                new PersonaComparada { Nombre="Carla", Apellido="Gómez", Edad=22, Altura=1.70, Peso=55 },
                new PersonaComparada { Nombre="Pedro", Apellido="Alonso", Edad=40, Altura=1.75, Peso=78 },
                new PersonaComparada { Nombre="Luis", Apellido="González", Edad=20, Altura=1.90, Peso=105 }
            };
            dataGridView2.DataSource = personasComparadas;

            personaOriginal = new PersonaClonable { Nombre = "Darío", Edad = 36 };
            personaClonadas = new List<PersonaClonable> { personaOriginal };
            dataGridView3.DataSource = personaClonadas;
        }
        private void RefreshDataGridView(DataGridView pDGV, object pO)
        {
            pDGV.DataSource = null; pDGV.DataSource = pO;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Ordenar el arreglo usando CompareTo
            personas.Sort();
            RefreshDataGridView(dataGridView1, personas);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int criterio = 1; // Nombre y Apellido
            personasComparadas.Sort(new ComparadorPersona(criterio));
            RefreshDataGridView(dataGridView2, personasComparadas);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int criterio = 2; // Edad
            personasComparadas.Sort(new ComparadorPersona(criterio));
            RefreshDataGridView(dataGridView2, personasComparadas);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int criterio = 3; // Altura
            personasComparadas.Sort(new ComparadorPersona(criterio));
            RefreshDataGridView(dataGridView2, personasComparadas);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int criterio = 4; // Peso
            personasComparadas.Sort(new ComparadorPersona(criterio));
            RefreshDataGridView(dataGridView2, personasComparadas);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            personaClonadas.Add(personaOriginal.ClonarTipado);
            RefreshDataGridView(dataGridView3, personaClonadas);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int[] datos = { 10, 20, 30, 40, 50 };
            ColeccionNumeros coleccion = new ColeccionNumeros(datos);

            string mensaje = "Números: ";
            foreach (int n in coleccion)
            {
                mensaje += $"{n}, ";
            }
            mensaje = mensaje.Substring(0, mensaje.Length - 2);
            MessageBox.Show(mensaje, "IEnumerable - IEnumerator", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
