using GestionMembresia.Components;
using GestionMembresia.Entities;
using GestionMembresia.Exceptions;
using GestionMembresia.Helpers;
using GestionMembresia.Validators;
using Microsoft.VisualBasic;
using System.Globalization;

namespace GestionMembresia
{
    public partial class Form1 : Form
    {
        private FormularioHelper formularioHelper;

        private List<Cliente> _clientes;
        private List<Membresia> _membresias;
        public Form1()
        {
            InitializeComponent();
            formularioHelper = new FormularioHelper();
            _clientes = new List<Cliente>();
            _membresias = new List<Membresia>();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Deshabilitar la seleccion mulitple de filas
            dataGridViewClientes.MultiSelect = false;
            dataGridViewMembresias.MultiSelect = false;
            // Modo de seleccion toda la fila, en lugar de celda por celda
            dataGridViewClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewMembresias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
                DataPropertyName = "ImporteCuota", // Usar la propiedad computa en un metodo
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
            string nombre = Interaction.InputBox("Ingrese nombre:", title, "").Trim();
            string apellido = Interaction.InputBox("Ingrese apellido:", title, "").Trim();
            string DNI = Interaction.InputBox($"Ingrese DNI:{Environment.NewLine}(Sin puntos)", title, "").Trim().Replace(".", "");

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
                string cuota = Interaction.InputBox("Ingrese valor de la cuota:", title, "").Trim();
                if (ValidadorCliente.ValidarValorCuota(cuota))
                    throw new ClienteInvalidoException("La cuota ingresada no es un numero valido.");

                // Crear cliente y agregarlo a la coleccion
                var nuevoCliente = new Cliente(formularioHelper.GenerarIdSocio(), nombre, apellido, DNI, categoriaSeleccionada, FormularioHelper.ConvertirADecimal(cuota));
                _clientes.Add(nuevoCliente);
                formularioHelper.ActualizarGrilla(dataGridViewClientes, _clientes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string nuevoNombre = Interaction.InputBox("Ingrese nombre:", title, clienteAModificar.Nombre).Trim();
                string nuevoApellido = Interaction.InputBox("Ingrese apellido:", title, clienteAModificar.Apellido).Trim();
                string nuevoDNI = Interaction.InputBox($"Ingrese DNI:{Environment.NewLine}(Sin puntos)", title, clienteAModificar.DNI.ToString()).Trim().Replace(".", "");

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
                string cuota = Interaction.InputBox("Ingrese valor de la cuota:", title, clienteAModificar.Cuota.ImporteOriginal.ToString()).Trim();
                if (ValidadorCliente.ValidarValorCuota(cuota))
                    throw new ClienteInvalidoException("La cuota ingresada no es un numero valido.");

                // Modificando los valores en la referencia del cliente
                clienteAModificar.Nombre = nuevoNombre;
                clienteAModificar.Apellido = nuevoApellido;
                clienteAModificar.DNI = nuevoDNI;
                clienteAModificar.Categoria = categoriaSeleccionada;
                clienteAModificar.Cuota.ImporteOriginal = FormularioHelper.ConvertirADecimal(cuota);
                clienteAModificar.Cuota.ValorConDescuento = clienteAModificar.Cuota.ImporteOriginal * (1 - clienteAModificar.Categoria.PorcentajeDescuento);
                formularioHelper.ActualizarGrilla(dataGridViewClientes, _clientes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Boton Membresias
        private void btnMembresiaAgregar_Click(object sender, EventArgs e)
        {
            // Validacion para que haya una fila seleccionada de la grilla de clientes
            if (dataGridViewClientes.Rows.Count == 0) return;

            try
            {
                // Obtener el numero de socio a registrar y encontrar la instancia a modificar
                string numeroSocioAAsociar = dataGridViewClientes.SelectedRows[0].Cells[0].Value.ToString();
                Cliente? clienteAAsociar = _clientes.Find(c => c.NumeroSocio.Equals(numeroSocioAAsociar));

                if (clienteAAsociar == null)
                    throw new ClienteInvalidoException("Ocurrió un error al crear la membresia.");

                if (clienteAAsociar.Membresia != null)
                    throw new MembresiaException("El cliente ya posee una membresia activa, editela o borrela antes de crear una nueva.");

                // Solicitar el ingreso de datos
                string title = $"Registro de membresia a {clienteAAsociar.Nombre} {clienteAAsociar.Apellido}";
                string descuentoIngresado = Interaction.InputBox("Ingrese el descuento: $", title, "").Trim();
                decimal descuentoIngresadoDecimal = 0;
                if (!decimal.TryParse(descuentoIngresado, NumberStyles.Number, CultureInfo.InvariantCulture, out descuentoIngresadoDecimal))
                        throw new MembresiaException($"El valor de descuento no es valido: ${clienteAAsociar.Cuota.ImporteOriginal}");

                // Creo una nueva membresia y se la asocio al cliente
                Membresia nuevaMembresia = new Membresia(formularioHelper.GenerarIdUnicoMembresias(), descuentoIngresadoDecimal);
                clienteAAsociar.AsignarMembresia(nuevaMembresia);
                _membresias.Add(nuevaMembresia);

                formularioHelper.ActualizarGrilla(dataGridViewClientes, _clientes);
                formularioHelper.ActualizarGrilla(dataGridViewMembresias, _membresias);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMembresiaModificar_Click(object sender, EventArgs e)
        {
            // Validacion para que haya una fila seleccionada de la grilla de clientes
            if (dataGridViewClientes.Rows.Count == 0) return;

            try
            {
                // Obtener el numero de socio a registrar y encontrar la instancia a modificar
                string numeroSocioAModificar = dataGridViewClientes.SelectedRows[0].Cells[0].Value.ToString();
                Cliente? clienteAModificar = _clientes.Find(c => c.NumeroSocio.Equals(numeroSocioAModificar));

                if (clienteAModificar == null)
                    throw new ClienteInvalidoException("Ocurrió un error al modificar la membresia del cliente.");

                if (clienteAModificar.Membresia == null)
                    throw new MembresiaException("El cliente no posee una membresia activa, cree una nueva por favor.");

                // Solicitar el ingreso de datos
                string title = $"Modificacion de membresia a {clienteAModificar.Nombre} {clienteAModificar.Apellido}";
                string descuentoIngresado = Interaction.InputBox("Ingrese el descuento: $", title, "").Trim();
                decimal descuentoIngresadoDecimal = 0;
                if (!decimal.TryParse(descuentoIngresado, NumberStyles.Number, CultureInfo.InvariantCulture, out descuentoIngresadoDecimal))
                    throw new MembresiaException($"El valor de descuento no es valido: ${clienteAModificar.Cuota.ImporteOriginal}");

                // obtengo la membresia y se la reasigno al cliente
                Membresia nuevaMembresia = clienteAModificar.Membresia;
                nuevaMembresia.Descuento = descuentoIngresadoDecimal;

                clienteAModificar.AsignarMembresia(nuevaMembresia);

                formularioHelper.ActualizarGrilla(dataGridViewClientes, _clientes);
                formularioHelper.ActualizarGrilla(dataGridViewMembresias, _membresias);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMembresiaBorrar_Click(object sender, EventArgs e)
        {
            // Validacion para que haya una fila seleccionada de la grilla de clientes
            if (dataGridViewClientes.Rows.Count == 0) return;

            try
            {
                // Obtener el numero de socio a registrar y encontrar la instancia a modificar
                string numeroSocioABorrar = dataGridViewClientes.SelectedRows[0].Cells[0].Value.ToString();
                Cliente? clienteABorrar = _clientes.Find(c => c.NumeroSocio.Equals(numeroSocioABorrar));

                if (clienteABorrar == null)
                    throw new ClienteInvalidoException("Ocurrió un error al borrar la membresia del cliente.");

                if (clienteABorrar.Membresia == null)
                    throw new MembresiaException("El cliente no posee una membresia activa, cree una nueva por continuar.");

                // Confirmar que se desea borrar al cliente
                var result = MessageBox.Show($"Seguro que quiere borrar a {clienteABorrar.Nombre} {clienteABorrar.Apellido}", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result.Equals(DialogResult.Yes))
                {
                    // Remover la mebresia de la lista
                    _membresias.Remove(clienteABorrar.Membresia);

                    // Remover la membresia del cliente
                    clienteABorrar.AsignarMembresia(null);
                }

                formularioHelper.ActualizarGrilla(dataGridViewClientes, _clientes);
                formularioHelper.ActualizarGrilla(dataGridViewMembresias, _membresias);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
