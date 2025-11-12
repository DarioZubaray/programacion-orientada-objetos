using Microsoft.VisualBasic;
using System.Globalization;

namespace GestorEdu
{
    public partial class Form1 : Form
    {
        private Instituto _institutoSeleccionado;
        private Proveedor _proveedorSeleccionado;
        private List<Instituto> _institutos;
        private List<Proveedor> _proveedores;
        private BindingSource _bsInstitutos;
        private BindingSource _bsProveedores;

        #region Inializacion
        public Form1()
        {
            InitializeComponent();
            _institutos = new List<Instituto>();
            _proveedores = new List<Proveedor>();
            _bsInstitutos = new BindingSource();
            _bsInstitutos = new BindingSource();
        }
        private void ApplyDefaultGridConfiguration(DataGridView dgv)
        {
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToOrderColumns = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ApplyDefaultGridConfiguration(dgvInstitutos);
            ApplyDefaultGridConfiguration(dgvProveedores);
            ApplyDefaultGridConfiguration(dgvProveedoresAsociados);
            ApplyDefaultGridConfiguration(dgvInstitutosAsociados);
            ApplyDefaultGridConfiguration(dgvPagosInstitutosProveedores);
            ApplyDefaultGridConfiguration(dgvPagos);

            _bsInstitutos.DataSource = _institutos;
            _bsInstitutos.DataSource = _proveedores;
            dgvInstitutos.DataSource = _bsInstitutos;
            dgvProveedores.DataSource = _bsProveedores;
        }
        #endregion

        #region RefresDataGrid
        private void RefreshDataGrid(DataGridView dgv, object datasource)
        {
            dgv.DataSource = null;
            dgv.DataSource = datasource;
        }

        private void RefreshDetailDataGrids(Instituto pInstituto, Proveedor pProveedor)
        {
            RefreshDataGrid(dgvProveedoresAsociados, pInstituto.Proveedores);
            RefreshDataGrid(dgvInstitutosAsociados,
                _institutos.Where(ins =>
                    ins.Proveedores.Any(p =>
                        p.Codigo.Equals(pProveedor.Codigo, StringComparison.OrdinalIgnoreCase)
                    )
                ).ToList());
        }

        private void RefreshDataGridInstitutosProveedoresPagos()
        {
            RefreshDataGrid(dgvPagosInstitutosProveedores,
                _institutos.Where(i => i.Codigo == _institutoSeleccionado.Codigo)
                    .SelectMany(i => i.Pagos)
                    .Where(p => p.Proveedor.Codigo == _proveedorSeleccionado.Codigo)
                    .OrderBy(p => p.FechaPago)
                    .Select(x => new
                    {
                        Instituto = x.Instituto.Nombre,
                        Proveedor = x.Proveedor.NombreORazonSocial,
                        Importe = x.Importe,
                        Fecha = x.FechaVencimiento
                    })
                    .ToList());
        }

        private void RefreshPagosDataGrid()
        {
            RefreshDataGrid(dgvPagos,
                _institutos.SelectMany(i => i.Pagos)
                            .OrderBy(p => p.Instituto.Codigo)
                            .Select(x => new
                            {
                                CodigoInstituto = x.Instituto.Codigo,
                                NombreInstituto = x.Instituto.Nombre,
                                NombrePrestador = x.Proveedor.NombreORazonSocial,
                                Importe = x.Importe,
                                Estado = x.Estado,
                                FechaVencimiento = x.FechaVencimiento
                            })
                            .ToList());
        }
        #endregion

        #region SelectionChanged
        private void dataGridViewIns_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvInstitutos.CurrentRow == null || dgvInstitutos.CurrentRow.Index < 0 || dgvInstitutos.SelectedRows.Count == 0 || dgvInstitutos.Rows.Count == 0)
                return;

            var fila = dgvInstitutos.SelectedRows[0];
            _institutoSeleccionado = fila.DataBoundItem as Instituto;
            if(_institutoSeleccionado == null)
            {
                return; // TODO informar error?
            }

            txtInsSeleccionado.Text = _institutoSeleccionado?.Nombre;

            btnInsModificar.Enabled = true;
            btnInsBorrar.Enabled = true;

            RefreshDataGrid(dgvProveedoresAsociados, _institutoSeleccionado.Proveedores);
            RefreshDataGridInstitutosProveedoresPagos();

            if(_proveedorSeleccionado != null)
            {
                btnInsProAsignarPrestador.Enabled = _institutoSeleccionado.Proveedores.Any(pro => pro.Codigo.Equals(_proveedorSeleccionado.Codigo));
                btnInsProGenerarPago.Enabled = _institutoSeleccionado.Pagos.Any(pago => pago.Proveedor.Codigo.Equals(_proveedorSeleccionado.Codigo));
            }
        }

        private void dataGridViewPro_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProveedores.CurrentRow == null || dgvProveedores.CurrentRow.Index < 0 || dgvProveedores.SelectedRows.Count == 0 || dgvProveedores.Rows.Count == 0)
                return;

            btnProModificar.Enabled = true;
            btnProBorrar.Enabled = true;

            var fila = dgvProveedores.SelectedRows[0];
            _proveedorSeleccionado = fila.DataBoundItem as Proveedor;
            if(_proveedorSeleccionado == null)
            {
                return; // TODO informar error?
            }

            txtProSeleccionado.Text = _proveedorSeleccionado.NombreORazonSocial;

            RefreshDataGrid(dgvInstitutosAsociados,
                _institutos.Where(ins =>
                    ins.Proveedores.Any(p =>
                        p.Codigo.Equals(_proveedorSeleccionado.Codigo, StringComparison.OrdinalIgnoreCase)
                    )
                ).ToList());
            RefreshDataGridInstitutosProveedoresPagos();

            if (_institutoSeleccionado != null)
            {
                btnInsProAsignarPrestador.Enabled = _institutoSeleccionado.Proveedores.Any(pro => pro.Codigo.Equals(_proveedorSeleccionado.Codigo));
                btnInsProGenerarPago.Enabled = _institutoSeleccionado.Pagos.Any(pago => pago.Proveedor.Codigo.Equals(_proveedorSeleccionado.Codigo));
            }
        }
        #endregion

        #region Botones Instituto
        private void btnInsNuevo_Click(object sender, EventArgs e)
        {
            string title = "Registro de institutos";
            string codigo = Interaction.InputBox("Ingrese Código:", title, "").Trim();
            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("El código no puede estar vacío.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool noEsCodigoUnico = _institutos.Any(i => i.Codigo.ToLower() == codigo.ToLower());
            if (noEsCodigoUnico)
            {
                MessageBox.Show($"Error: El código de instituto ingresado [{codigo}] ya existe.", title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string nombre = Interaction.InputBox("Ingrese Nombre:", title, "").Trim();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El Nombre no puede estar vacío.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string telefono = Interaction.InputBox("Ingrese Teléfono:", title, "").Trim();
            if (string.IsNullOrWhiteSpace(telefono))
            {
                MessageBox.Show("El Teléfono no puede estar vacío.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string direccion = Interaction.InputBox("Ingrese Dirección:", title, "").Trim();
            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("La Dirección no puede estar vacía.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nuevoInstituto = new Instituto(codigo, nombre, telefono, direccion);

            _institutos.Add(nuevoInstituto);
            RefreshDataGrid(dgvInstitutos, _institutos);
        }

        private void btnInsModificar_Click(object sender, EventArgs e)
        {
            if (dgvInstitutos.CurrentRow == null || dgvInstitutos.SelectedRows.Count == 0 || dgvInstitutos.Rows.Count == 0 || dgvInstitutos.CurrentRow.Index < 0)
                return;

            var fila = dgvInstitutos.SelectedRows[0];
            Instituto? institutoSeleccionado = fila.DataBoundItem as Instituto;
            string title = "Modificación de institutos";
            if (institutoSeleccionado == null)
            {
                MessageBox.Show("Ocurrió un error al modificar el instituto seleccionado.", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string codigo = Interaction.InputBox("Ingrese Código:", title, institutoSeleccionado.Codigo).Trim();
            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("El Código no puede estar vacío.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool noEsCodigoUnico = _institutos.Any(i => i.Codigo.ToLower() == codigo.ToLower());
            if (noEsCodigoUnico)
            {
                MessageBox.Show($"Error: El código de instituto ingresado [{codigo}] ya existe.", title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string nombre = Interaction.InputBox("Ingrese Nombre:", title, institutoSeleccionado.Nombre).Trim();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El Nombre no puede estar vacío.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string telefono = Interaction.InputBox("Ingrese Teléfono:", title, institutoSeleccionado.Telefono).Trim();
            if (string.IsNullOrWhiteSpace(telefono))
            {
                MessageBox.Show("El Teléfono no puede estar vacío.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string direccion = Interaction.InputBox("Ingrese Dirección:", title, institutoSeleccionado.Direccion).Trim();
            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("La Dirección no puede estar vacía.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            institutoSeleccionado.Codigo = codigo;
            institutoSeleccionado.Nombre = nombre;
            institutoSeleccionado.Telefono = telefono;
            institutoSeleccionado.Direccion = direccion;
            RefreshDataGrid(dgvInstitutos, _institutos);
        }

        private void btnInsBorrar_Click(object sender, EventArgs e)
        {
            if (dgvInstitutos.CurrentRow == null || dgvInstitutos.SelectedRows.Count == 0 || dgvInstitutos.Rows.Count == 0 || dgvInstitutos.CurrentRow.Index < 0)
                return;

            var fila = dgvInstitutos.SelectedRows[0];
            Instituto? institutoSeleccionado = fila.DataBoundItem as Instituto;
            string title = "Eliminación de institutos";
            if (institutoSeleccionado == null)
            {
                MessageBox.Show("Ocurrió un error al intentar borrar el instituto seleccionado.", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // validar que NO posea pagos pendientes a sus prestadores
            var conPagos = _institutos.Where(ins => ins.Pagos.Any(p => p.Estado == EstadoPago.No_Cancelado)).ToList();
            if (conPagos.Count > 0)
            {
                MessageBox.Show($"No es posible borrar el instituto {institutoSeleccionado} seleccionado, ya que posee pagos pendientes.", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show($"Seguro que quiere borrar al instituto '{institutoSeleccionado}'", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result.Equals(DialogResult.Yes))
            {
                _institutos.Remove(institutoSeleccionado);
                RefreshDataGrid(dgvInstitutos, _institutos);
                if (dgvInstitutos.Rows.Count == 0)
                {
                    txtInsSeleccionado.Text = "";
                    btnInsModificar.Enabled = false;
                    btnInsBorrar.Enabled = false;
                    btnInsProAsignarPrestador.Enabled = false;
                    btnInsProGenerarPago.Enabled = false;
                    return;
                }
            }
        }
        #endregion

        #region Botones Proveedores
        private void btnProNuevo_Click(object sender, EventArgs e)
        {
            string title = "Registro de proveedores";
            string codigo = Interaction.InputBox("Ingrese Código:", title, "").Trim();
            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("El código no puede estar vacío.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool noEsCodigoUnico = _proveedores.Any(i => i.Codigo.ToLower() == codigo.ToLower());
            if (noEsCodigoUnico)
            {
                MessageBox.Show($"Error: El Código de instituto ingresado [{codigo}] ya existe.", title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string nombre = Interaction.InputBox("Ingrese Nombre o Razón Social:", title, "").Trim();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El Nombre no puede estar vacío.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string telefono = Interaction.InputBox("Ingrese Teléfono:", title, "").Trim();
            if (string.IsNullOrWhiteSpace(telefono))
            {
                MessageBox.Show("El Teléfono no puede estar vacío.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nuevoProveedor = new Proveedor(codigo, nombre, telefono);

            _proveedores.Add(nuevoProveedor);
            RefreshDataGrid(dgvProveedores, _proveedores);
        }

        private void btnProModificar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.CurrentRow == null || dgvProveedores.SelectedRows.Count == 0 || dgvProveedores.Rows.Count == 0 || dgvProveedores.CurrentRow.Index < 0)
                return;

            var fila = dgvProveedores.SelectedRows[0];
            Proveedor? proveedorSeleccionado = fila.DataBoundItem as Proveedor;
            string title = "Modificación de proveedores";
            if (proveedorSeleccionado == null)
            {
                MessageBox.Show("Ocurrió un error al modificar el proveedor seleccionado.", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string codigo = Interaction.InputBox("Ingrese Código:", title, proveedorSeleccionado.Codigo).Trim();
            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("El Código no puede estar vacío.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool noEsCodigoUnico = _proveedores.Any(i => i.Codigo.ToLower() == codigo.ToLower());
            if (noEsCodigoUnico)
            {
                MessageBox.Show($"Error: El código de instituto ingresado [{codigo}] ya existe.", title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string nombre = Interaction.InputBox("Ingrese Nombre o Razón Social:", title, proveedorSeleccionado.NombreORazonSocial).Trim();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El Nombre o Razón Social no puede estar vacío.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string telefono = Interaction.InputBox("Ingrese Teléfono:", title, proveedorSeleccionado.Telefono).Trim();
            if (string.IsNullOrWhiteSpace(telefono))
            {
                MessageBox.Show("El Teléfono no puede estar vacío.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            proveedorSeleccionado.Codigo = codigo;
            proveedorSeleccionado.NombreORazonSocial = nombre;
            proveedorSeleccionado.Telefono = telefono;
            RefreshDataGrid(dgvProveedores, _proveedores);
        }

        private void btnProBorrar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.CurrentRow == null || dgvProveedores.SelectedRows.Count == 0 || dgvProveedores.Rows.Count == 0 || dgvProveedores.CurrentRow.Index < 0)
                return;

            var fila = dgvProveedores.SelectedRows[0];
            Proveedor? proveedorSeleccionado = fila.DataBoundItem as Proveedor;
            string title = "Eliminación de proveedores";
            if (proveedorSeleccionado == null)
            {
                MessageBox.Show("Ocurrió un error al intentar borrar el proveedor seleccionado.", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Validar que NO tenga institutos asignados
            if (proveedorSeleccionado.Institutos.Count > 0)
            {
                MessageBox.Show($"El Proveedor '{proveedorSeleccionado}' no puede ser eliminado ya que cuenta con Institutos asociados.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Seguro que quiere borrar al proveedor '{proveedorSeleccionado}'", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result.Equals(DialogResult.Yes))
            {
                _proveedores.Remove(proveedorSeleccionado);
                RefreshDataGrid(dgvProveedores, _proveedores);
                if (dgvProveedores.Rows.Count == 0)
                {
                    txtProSeleccionado.Text = "";
                    btnProModificar.Enabled = false;
                    btnProBorrar.Enabled = false;
                    btnInsProAsignarPrestador.Enabled = false;
                    btnInsProGenerarPago.Enabled = false;
                }
            }
        }
        #endregion

        #region Asignacion
        private void btnInsProAsignarPrestador_Click(object sender, EventArgs e)
        {
            if (dgvInstitutos.CurrentRow == null || dgvInstitutos.SelectedRows.Count == 0 || dgvInstitutos.Rows.Count == 0 || dgvInstitutos.CurrentRow.Index < 0)
            {
                MessageBox.Show($"Ocurrió un error en la grilla de institutos al momento de la asignación.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dgvProveedores.CurrentRow == null || dgvProveedores.SelectedRows.Count == 0 || dgvProveedores.Rows.Count == 0 || dgvProveedores.CurrentRow.Index < 0)
            {
                MessageBox.Show($"Ocurrió un error en la grilla de proveedores al momento de la asignación.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // tomar institutoSeleccionado y proveedorSeleccionado
            var filaInstituto = dgvInstitutos.SelectedRows[0];
            Instituto? institutoSeleccionado = filaInstituto.DataBoundItem as Instituto;
            var filaProveedor = dgvProveedores.SelectedRows[0];
            Proveedor? proveedorSeleccionado = filaProveedor.DataBoundItem as Proveedor;

            // Validar que NO se encuentre ya asignado
            var yaSeEncuentraAsignado = institutoSeleccionado.Proveedores.Any(p => p.Codigo == proveedorSeleccionado.Codigo);
            if (yaSeEncuentraAsignado)
            {
                MessageBox.Show($"No se puede volver a asignar el proveedor '{proveedorSeleccionado}' al instituto {institutoSeleccionado}.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // asignar
            institutoSeleccionado.AsignarProveedor(proveedorSeleccionado);

            // refrescar grillas 3 y 4
            RefreshDetailDataGrids(institutoSeleccionado, proveedorSeleccionado);

            // Activar como verdaro el boton de generar pago
            btnInsProGenerarPago.Enabled = true;
        }

        private void btnInsProGenerarPago_Click(object sender, EventArgs e)
        {
            if (dgvInstitutos.CurrentRow == null || dgvInstitutos.SelectedRows.Count == 0 || dgvInstitutos.Rows.Count == 0 || dgvInstitutos.CurrentRow.Index < 0)
            {
                MessageBox.Show($"Ocurrió un error en la grilla de institutos al momento de la generación de un nuevo pago.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dgvProveedores.CurrentRow == null || dgvProveedores.SelectedRows.Count == 0 || dgvProveedores.Rows.Count == 0 || dgvProveedores.CurrentRow.Index < 0)
            {
                MessageBox.Show($"Ocurrió un error en la grilla de proveedores al momento de la generación de un nuevo pago.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // tomar institutoSeleccionado y proveedorSeleccionado
            var filaInstituto = dgvInstitutos.SelectedRows[0];
            Instituto? institutoSeleccionado = filaInstituto.DataBoundItem as Instituto;
            var filaProveedor = dgvProveedores.SelectedRows[0];
            Proveedor? proveedorSeleccionado = filaProveedor.DataBoundItem as Proveedor;

            // ingresar los datos de pago
            string title = "Registro de Pagos";
            string importe = Interaction.InputBox("Ingrese importe:", title, "").Trim().Replace('.', ',');
            if (!decimal.TryParse(importe, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal valor))
            {
                MessageBox.Show($"El Número [{valor}] ingresado no es válido.", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string fechaVencimiento = Interaction.InputBox("Ingrese la fecha de vencimiento:", title, "").Trim().Replace('.', ',');
            DateTime fecha;
            if (!DateTime.TryParseExact(fechaVencimiento,
                "dd/MM/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out fecha))
            {
                MessageBox.Show($"La Fecha [{fechaVencimiento}] ingresada no es válida.", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // Validar que sea mayor al día de hoy
            if (fecha <= DateTime.Today)
            {
                MessageBox.Show("La fecha de vencimiento debe ser posterior al día de hoy.", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            institutoSeleccionado.RegistrarPago(proveedorSeleccionado, decimal.Parse(importe), fecha);
            RefreshDataGridInstitutosProveedoresPagos();
            RefreshPagosDataGrid();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
