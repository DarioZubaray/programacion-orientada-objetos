using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace TPIntegrador_Unidad4
{
    public partial class Form1 : Form
    {
        List<Alumno> ListaAlumnos;
        public Form1()
        {
            InitializeComponent();
            ListaAlumnos = new List<Alumno>();
            dataGridView1.DataSource = ListaAlumnos;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void Mostrar(DataGridView pDGV, object pO)
        {
            pDGV.DataSource = null; pDGV.DataSource = pO;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string title = "Registro de alumno";
            string nombre = Interaction.InputBox("Ingrese nombre:", title, "");
            string apellido = Interaction.InputBox("Ingrese apellido:", title, "");
            DateTime fechaNacimiento;
            try
            {
                string fechaNacimientoIngresada = Interaction.InputBox("Ingrese fecha de nacimiento:", title, "dd/mm/yyyy");
                fechaNacimiento = DateTime.ParseExact(fechaNacimientoIngresada, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            } catch
            {
                fechaNacimiento = DateTime.Now;
            }

            int nuevoLegajo = ListaAlumnos.Any() ? ListaAlumnos.Max(a => a.Legajo) + 1 : 1;
            Alumno nuevoAlumno = new Alumno(nuevoLegajo, nombre, apellido, fechaNacimiento);
            ListaAlumnos.Add(nuevoAlumno);

            Mostrar(dataGridView1, Alumno.CopiaListaAlumnos(ListaAlumnos));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0) return;

            int legajoABorrar = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            Alumno alumnoABorrar = ListaAlumnos.Find(alumno => alumno.Legajo.Equals(legajoABorrar));

            var result = MessageBox.Show($"Seguro que quiere borrar a {alumnoABorrar.NombreCompleto()}", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result.Equals(DialogResult.Yes))
            {
                ListaAlumnos.Remove(alumnoABorrar);
                Mostrar(dataGridView1, Alumno.CopiaListaAlumnos(ListaAlumnos));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0) return;

            int legajoAModificar = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            Alumno alumnoAModificar = ListaAlumnos.Find(alumno => alumno.Legajo.Equals(legajoAModificar));
            if(alumnoAModificar == null)
            {
                MessageBox.Show("Ocurrio un error al modificar el alumno.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string title = "Modificación de alumno";
            string nuevoNombre = Interaction.InputBox("Ingrese nombre:", title, alumnoAModificar.Nombre);
            string nuevoApellido = Interaction.InputBox("Ingrese apellido:", title, alumnoAModificar.Apellido);
            string nuevaFechaNacimiento = Interaction.InputBox("Ingrese fecha de nacimiento:", title, "");
            string nuevaCantMateriasAprobadas = Interaction.InputBox("Ingrese cantidad de materias aprobadas:", title, "0");
            alumnoAModificar.Nombre = nuevoNombre;
            alumnoAModificar.Apellido = nuevoApellido;
            alumnoAModificar.FechaNacimiento = DateTime.ParseExact(nuevaFechaNacimiento, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            alumnoAModificar.CantMateriaAprobadas = Convert.ToInt32(nuevaCantMateriasAprobadas);
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dataGridView1.Rows[e.RowIndex];
                var alumnoMouseEnter = fila.DataBoundItem as Alumno;

                if (alumnoMouseEnter != null)
                {
                    textBox1.Text = alumnoMouseEnter.Antiguedad("años").ToString();
                    textBox2.Text = alumnoMouseEnter.MateriasNoAprobadas().ToString();
                    textBox3.Text = alumnoMouseEnter.EdadDeIngreso().ToString();
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                Alumno seleccionado = dataGridView1.CurrentRow.DataBoundItem as Alumno;
                if (seleccionado != null)
                {
                    textBox1.Text = seleccionado.Antiguedad("años").ToString();
                    textBox2.Text = seleccionado.MateriasNoAprobadas().ToString();
                    textBox3.Text = seleccionado.EdadDeIngreso().ToString();
                }
            }
        }
    }
}
