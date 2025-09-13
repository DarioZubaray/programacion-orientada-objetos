using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ActividadIntegradoraUnidad1
{
    public partial class Form1 : Form
    {
        List<Persona> ListaPersonas;
        List<Auto> ListaAutos;

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            ListaPersonas = new List<Persona>();
            ListaAutos = new List<Auto>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void Mostrar(DataGridView pDGV, object pO)
        {
            pDGV.DataSource = null; pDGV.DataSource = pO;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string title = "Registro de persona";
            string dni = Interaction.InputBox($"Ingrese el DNI: {Environment.NewLine} Sin puntos, ejemplo: 12345678", title, "");
            int.TryParse(dni, out int numeroDni);
            string nombre = Interaction.InputBox("Ingrese nombre:", title, "");
            string apellido = Interaction.InputBox("Ingrese apellido:", title, "");

            if (numeroDni == 0 || nombre.Length < 1 || apellido.Length < 1)
            {
                MessageBox.Show("Debe ingresar valores válidos", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Persona nuevaPersona = new Persona(dni, nombre, apellido);
            ListaPersonas.Add(nuevaPersona);

            Mostrar(dataGridView1, ListaPersonas.ToList());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0) return;

            string dniPersonaABorrar = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value).ToString();
            Persona personaABorrar = ListaPersonas.Find(persona => persona.DNI.Equals(dniPersonaABorrar));

            var result = MessageBox.Show($"Seguro que quiere borrar a {personaABorrar.DNI}", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result.Equals(DialogResult.Yes))
            {
                ListaPersonas.Remove(personaABorrar);
                Mostrar(dataGridView1, ListaPersonas.ToList());
                Mostrar(dataGridView3, null);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0) return;

            string dniPersonaAModificar = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value).ToString();
            Persona personaAModificar = ListaPersonas.Find(persona => persona.DNI.Equals(dniPersonaAModificar));
            if (personaAModificar == null)
            {
                MessageBox.Show("Ocurrio un error al modificar la persona.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string title = "Modificación de persona";
            string nuevoNombre = Interaction.InputBox("Ingrese nombre:", title, personaAModificar.Nombre);
            string nuevoApellido = Interaction.InputBox("Ingrese apellido:", title, personaAModificar.Apellido);
            if (nuevoNombre.Length < 1 || nuevoApellido.Length < 1)
            {
                MessageBox.Show("Debe ingresar valores válidos", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            personaAModificar.Nombre = nuevoNombre;
            personaAModificar.Apellido = nuevoApellido;

            Mostrar(dataGridView1, ListaPersonas.ToList());
            Mostrar(dataGridView3, personaAModificar.ListaDeAutos());
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                Persona personaSeleccionada = dataGridView1.CurrentRow.DataBoundItem as Persona;
                if (personaSeleccionada != null)
                {
                    label1.Text = $"a: {personaSeleccionada.Nombre} {personaSeleccionada.Apellido}";
                    Mostrar(dataGridView3, personaSeleccionada.ListaDeAutos());
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string title = "Registro de auto";
            string patente = Interaction.InputBox($"Ingrese el número de patente:", title, "");
            string marca = Interaction.InputBox("Ingrese el nombre de la marca:", title, "");
            string modelo = Interaction.InputBox("Ingrese el nombre del modelo:", title, "");
            string anio = Interaction.InputBox("Ingrese el año:", title, "");
            string precio = Interaction.InputBox("Ingrese el precio:", title, "");

            if (patente.Length < 1 || marca.Length < 1 || modelo.Length < 1 || anio.Length < 1 || precio.Length < 1)
            {
                MessageBox.Show("Debe ingresar valores válidos", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            decimal precioDecimal = Decimal.Parse(precio);
            Auto nuevoAuto = new(patente, marca, modelo, anio, precioDecimal);
            ListaAutos.Add(nuevoAuto);

            Mostrar(dataGridView2, ListaAutos.ToList());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count == 0) return;

            string patenteAutoABorrar = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value).ToString();
            Auto autoABorrar = ListaAutos.Find(auto => auto.Patente.Equals(patenteAutoABorrar));

            var result = MessageBox.Show($"Seguro que quiere borrar a {autoABorrar.Patente}", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result.Equals(DialogResult.Yes))
            {
                ListaAutos.Remove(autoABorrar);
                Mostrar(dataGridView2, ListaAutos.ToList());
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count == 0) return;

            string patenteAutoAModificar = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value).ToString();
            Auto autoAModificar = ListaAutos.Find(auto => auto.Patente.Equals(patenteAutoAModificar));
            if (autoAModificar == null)
            {
                MessageBox.Show("Ocurrio un error al modificar el auto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string title = "Modificación de auto";
            string nuevaMarca = Interaction.InputBox("Ingrese apellido:", title, autoAModificar.Marca);
            string nuevoModelo = Interaction.InputBox("Ingrese nombre:", title, autoAModificar.Modelo);
            string nuevoAnio = Interaction.InputBox("Ingrese nombre:", title, autoAModificar.Anio);
            string nuevoPrecio = Interaction.InputBox("Ingrese nombre:", title, autoAModificar.Precio.ToString());

            if (nuevaMarca.Length < 1 || nuevoModelo.Length < 1 || nuevoAnio.Length < 1 || nuevoPrecio.Length < 1)
            {
                MessageBox.Show("Debe ingresar valores válidos", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            autoAModificar.Marca = nuevaMarca;
            autoAModificar.Modelo = nuevoModelo;
            autoAModificar.Anio = nuevoAnio;
            decimal precioDecimal = Decimal.Parse(nuevoPrecio);
            autoAModificar.Precio = precioDecimal;

            Mostrar(dataGridView2, ListaAutos.ToList());
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
                Auto autoSeleccionado = dataGridView2.CurrentRow.DataBoundItem as Auto;
                if (autoSeleccionado != null)
                {
                    label2.Text = $"auto: [{autoSeleccionado.Patente}] {autoSeleccionado.Marca} - {autoSeleccionado.Modelo} ({autoSeleccionado.Anio})";

                    List<string> dataSorceGrid4 = new List<String> { 
                        autoSeleccionado.Marca, autoSeleccionado.Anio, autoSeleccionado.Modelo, autoSeleccionado.Patente,
                        autoSeleccionado.Dueño != null ? autoSeleccionado.Dueño.DNI : "-",
                        autoSeleccionado.ObtenerNombreDueño()
                    };
                    var fila = new[]
                    {
                        new
                        {
                            Marca = dataSorceGrid4[0],
                            Año = dataSorceGrid4[1],
                            Modelo = dataSorceGrid4[2],
                            Patente = dataSorceGrid4[3],
                            Dni = dataSorceGrid4[4],
                            Nombre = dataSorceGrid4[5]
                        }
                    };
                    Mostrar(dataGridView4, fila);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView2.CurrentRow != null)
            {
                Auto autoSeleccionado = dataGridView2.CurrentRow.DataBoundItem as Auto;
                Persona personaSeleccionada = dataGridView1.CurrentRow.DataBoundItem as Persona;
                if (personaSeleccionada != null && autoSeleccionado != null)
                {
                    Persona personaEnLista = ListaPersonas.Find(p => p.DNI.Equals(personaSeleccionada.DNI));
                    personaEnLista.AgregarAuto(autoSeleccionado);
                    Auto autoEnLista = ListaAutos.Find(a => a.Patente.Equals(autoSeleccionado.Patente));
                    autoEnLista.Dueño = personaEnLista;

                    Mostrar(dataGridView3, personaEnLista.ListaDeAutos());
                }
            }
        }

    }
}
