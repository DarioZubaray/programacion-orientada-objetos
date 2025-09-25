using GestionMembresia.Components;
using GestionMembresia.Entities;
using GestionMembresia.Exceptions;
using GestionMembresia.Helpers;
using GestionMembresia.Validators;
using Microsoft.VisualBasic;

namespace GestionMembresia
{
    public partial class Form1 : Form
    {
        private FormularioHelper formularioHelper;

        private List<Cliente> _clientes;
        public Form1()
        {
            InitializeComponent();
            formularioHelper = new FormularioHelper();
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
            dataGridViewClientes.Columns["ImporteCuota"].DefaultCellStyle.Format = "C2";
        }


        #region Boton Cliente
        private void btnClienteAgregar_Click(object sender, EventArgs e)
        {
            // Solicitar el ingreso de datos
            string title = "Registro de cliente";
            string nombre = Interaction.InputBox("Ingrese nombre:", title, "");
            string apellido = Interaction.InputBox("Ingrese apellido:", title, "");
            string DNI = Interaction.InputBox("Ingrese DNI:", title, "");

            try
            {
                // Validar los datos ingresados
                if (!ValidadorCliente.ValidarCliente(nombre, apellido, DNI))
                    throw new ClienteInvalidoException("Los datos ingresados no son válidos.");

                // Invocar al componente formulario selector personalizado
                var form = new SelectorCategoriaForm();
                Categoria categoriaSeleccionada = new Principiante();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    categoriaSeleccionada = form.Resultado; // instancia de Principiante, Intermedio o Avanzado
                }

                // Solicitar le valor de la cuota del socio
                string cuota = Interaction.InputBox("Ingrese valor de la cuota:", title, "");
                if (ValidadorCliente.ValidarValorCuota(cuota))
                    throw new ClienteInvalidoException("La cuota ingresada no es un numero valido.");

                // Crear cliente y agregarlo a la coleccion
                var nuevoCliente = new Cliente(formularioHelper.GenerarIdSocio(), nombre, apellido, DNI, categoriaSeleccionada, FormularioHelper.ConvertirADecimal(cuota));
                _clientes.Add(nuevoCliente);
                formularioHelper.ActualizarGrilla(dataGridViewClientes, _clientes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnClienteModificar_Click(object sender, EventArgs e)
        {
            // Validacion para que haya una fila seleccionada
            if (dataGridViewClientes.Rows.Count == 0) return;

            try
            {
                // Obtener el numero de socio y encontrar la instancia a modificar
                string numeroSocioAModificar = dataGridViewClientes.SelectedRows[0].Cells[0].Value.ToString();
                Cliente? clienteAModificar = _clientes.Find(c => c.NumeroSocio.Equals(numeroSocioAModificar));

                if (clienteAModificar == null)
                    throw new ClienteInvalidoException("Ocurrió un error al modificar el cliente.");

                // Modificacion de datos basicos
                string title = "Modificación de cliente";
                string nuevoNombre = Interaction.InputBox("Ingrese nombre:", title, clienteAModificar.Nombre);
                string nuevoApellido = Interaction.InputBox("Ingrese apellido:", title, clienteAModificar.Apellido);
                string nuevoDNI = Interaction.InputBox("Ingrese DNI:", title, clienteAModificar.DNI.ToString());

                // Validar los datos ingresados
                if (!ValidadorCliente.ValidarCliente(nuevoNombre, nuevoApellido, nuevoDNI))
                    throw new ClienteInvalidoException("Los datos ingresados no son válidos.");

                // Invocar al componente formulario selector personalizado
                var form = new SelectorCategoriaForm();
                Categoria categoriaSeleccionada = new Principiante();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    categoriaSeleccionada = form.Resultado; // instancia de Principiante, Intermedio o Avanzado
                }

                // Solicitar le valor de la cuota del socio
                string cuota = Interaction.InputBox("Ingrese valor de la cuota:", title, clienteAModificar.Cuota.Importe.ToString());
                if (ValidadorCliente.ValidarValorCuota(cuota))
                    throw new ClienteInvalidoException("La cuota ingresada no es un numero valido.");

                // Modificando los valores en la referencia del cliente
                clienteAModificar.Nombre = nuevoNombre;
                clienteAModificar.Apellido = nuevoApellido;
                clienteAModificar.DNI = nuevoDNI;
                clienteAModificar.Categoria = categoriaSeleccionada;
                clienteAModificar.Cuota.Importe = FormularioHelper.ConvertirADecimal(cuota);
                formularioHelper.ActualizarGrilla(dataGridViewClientes, _clientes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnClienteBorrar_Click(object sender, EventArgs e)
        {
            // Validacion para que haya una fila seleccionada
            if (dataGridViewClientes.Rows.Count == 0) return;

            try
            {
                // Se busca el cliente a borrar por numero de socio
                string numeroSocioABorrar = dataGridViewClientes.SelectedRows[0].Cells[0].Value.ToString();
                Cliente? clienteABorrar = _clientes.Find(c => c.NumeroSocio.Equals(numeroSocioABorrar));

                if (clienteABorrar == null)
                    throw new ClienteInvalidoException("Ocurrio un error al borrar el cliente.");

                // Confirmar que se desea borrar al cliente
                var result = MessageBox.Show($"Seguro que quiere borrar a {clienteABorrar.Nombre} {clienteABorrar.Apellido}", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result.Equals(DialogResult.Yes))
                {
                    // Remover cliente de la lista por objeto
                    _clientes.Remove(clienteABorrar);
                    formularioHelper.ActualizarGrilla(dataGridViewClientes, _clientes);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}
