using GestionMembresia.Entities;
using GestionMembresia.Validators;
using Microsoft.VisualBasic;

namespace GestionMembresia
{
    public partial class Form1 : Form
    {
        private List<Cliente> _clientes;
        public Form1()
        {
            InitializeComponent();
            _clientes = new List<Cliente>();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Deshabilitar la seleccion mulitple de filas
            dataGridViewClientes.MultiSelect = false;
            // Modo de seleccion toda la fila, en lugar de celda por celda
            dataGridViewClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // Deshabilitar generación automática de columnas
            dataGridViewClientes.AutoGenerateColumns = false;

            // Definir columnas manualmente
            dataGridViewClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NumeroSocio",
                HeaderText = "Número de Socio",
                Name = "NumeroSocio"
            });
            dataGridViewClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Name = "Nombre"
            });
            dataGridViewClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Apellido",
                HeaderText = "Apellido",
                Name = "Apellido"
            });
            dataGridViewClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DNI",
                HeaderText = "DNI",
                Name = "DNI"
            });
            dataGridViewClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ImporteCuota", // Usar la propiedad agregada
                HeaderText = "Importe Cuota",
                Name = "ImporteCuota"
            });
        }

        private void ActualizarGrilla<T>(DataGridView pDGV, List<T> pO)
        {
            if (pO == null) return;
            pDGV.DataSource = null;
            pDGV.DataSource = pO;
        }

        #region Boton Cliente
        private void btnClienteAgregar_Click(object sender, EventArgs e)
        {
            // Solicitar el ingreso de datos
            string title = "Registro de cliente";
            string nombre = Interaction.InputBox("Ingrese nombre:", title, "");
            string apellido = Interaction.InputBox("Ingrese apellido:", title, "");
            string DNI = Interaction.InputBox("Ingrese DNI:", title, "");

            // Validar los datos ingresados
            if (!ValidadorCliente.ValidarCliente(nombre, apellido, DNI))
            {
                MessageBox.Show("Los datos ingresados no son válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Crear cliente y agregarlo a la coleccion
            var nuevoCliente = new Cliente("AB02", apellido, nombre, DNI, new Principiante(), 1500.5m);
            _clientes.Add(nuevoCliente);
            ActualizarGrilla(dataGridViewClientes, _clientes);
        }

        private void btnClienteModificar_Click(object sender, EventArgs e)
        {

        }

        private void btnClienteBorrar_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
