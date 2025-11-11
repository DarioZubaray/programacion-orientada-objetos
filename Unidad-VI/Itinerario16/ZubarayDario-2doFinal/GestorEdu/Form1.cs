using Microsoft.VisualBasic;

namespace GestorEdu
{
    public partial class Form1 : Form
    {
        private List<Instituto> _institutos;
        private List<Proveedor> _proveedores;
        private BindingSource _bsInstitutos;
        private BindingSource _bsProveedores;
        private bool hayInstitutoSeleccionado = false;
        private bool hayProveedorSeleccionado = false;

        public Form1()
        {
            InitializeComponent();
            _institutos = new List<Instituto>();
            _proveedores = new List<Proveedor>();
            _bsInstitutos = new BindingSource();
            _bsInstitutos = new BindingSource();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridViewIns.MultiSelect = false;
            dataGridViewIns.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewIns.AllowUserToOrderColumns = true;

            dataGridViewPro.MultiSelect = false;
            dataGridViewPro.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPro.AllowUserToOrderColumns = true;

            _bsInstitutos.DataSource = _institutos;
            _bsInstitutos.DataSource = _proveedores;
            dataGridViewIns.DataSource = _bsInstitutos;
            dataGridViewPro.DataSource = _bsProveedores;
        }

        private void RefreshDataGrid(DataGridView dgv, object datasource)
        {
            dgv.DataSource = null;
            dgv.DataSource = datasource;
        }

        private void RefreshDetailDataGrids(Instituto instituto, Proveedor proveedor)
        {
            RefreshDataGrid(dataGridViewPrestadoresInstituto, instituto.Proveedores);
            RefreshDataGrid(dataGridViewInstitutoProveedores,
                _institutos.Where(ins =>
                    ins.Proveedores.Any(p =>
                        p.Codigo.Equals(proveedor.Codigo, StringComparison.OrdinalIgnoreCase)
                    )
                ).ToList());
        }

        private void dataGridViewIns_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewIns.CurrentRow == null || dataGridViewIns.CurrentRow.Index < 0 || dataGridViewIns.SelectedRows.Count == 0 || dataGridViewIns.Rows.Count == 0)
                return;

            var fila = dataGridViewIns.SelectedRows[0];
            var institutoSeleccionado = fila.DataBoundItem as Instituto;
            txtInsSeleccionado.Text = institutoSeleccionado?.Nombre;

            btnInsModificar.Enabled = true;
            btnInsBorrar.Enabled = true;
            hayInstitutoSeleccionado = true;

            btnInsProAsignarPrestador.Enabled = hayInstitutoSeleccionado && hayProveedorSeleccionado;
            btnInsProGenerarPago.Enabled = hayInstitutoSeleccionado && hayProveedorSeleccionado;

            RefreshDataGrid(dataGridViewPrestadoresInstituto, institutoSeleccionado.Proveedores);
        }

        private void dataGridViewPro_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewPro.CurrentRow == null || dataGridViewPro.CurrentRow.Index < 0 || dataGridViewPro.SelectedRows.Count == 0 || dataGridViewPro.Rows.Count == 0)
                return;

            btnProModificar.Enabled = true;
            btnProBorrar.Enabled = true;
            hayProveedorSeleccionado = true;

            var fila = dataGridViewPro.SelectedRows[0];
            var proveedorSeleccionado = fila.DataBoundItem as Proveedor;
            txtProSeleccionado.Text = proveedorSeleccionado?.NombreORazonSocial;

            btnInsProAsignarPrestador.Enabled = hayInstitutoSeleccionado && true;
            btnInsProGenerarPago.Enabled = hayInstitutoSeleccionado && true;

            RefreshDataGrid(dataGridViewInstitutoProveedores,
                _institutos.Where(ins =>
                    ins.Proveedores.Any(p =>
                        p.Codigo.Equals(proveedorSeleccionado.Codigo, StringComparison.OrdinalIgnoreCase)
                    )
                ).ToList());
        }


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
            RefreshDataGrid(dataGridViewIns, _institutos);
        }

        private void btnInsModificar_Click(object sender, EventArgs e)
        {
            if (dataGridViewIns.CurrentRow == null || dataGridViewIns.SelectedRows.Count == 0 || dataGridViewIns.Rows.Count == 0 || dataGridViewIns.CurrentRow.Index < 0)
                return;

            var fila = dataGridViewIns.SelectedRows[0];
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
            RefreshDataGrid(dataGridViewIns, _institutos);
        }

        private void btnInsBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridViewIns.CurrentRow == null || dataGridViewIns.SelectedRows.Count == 0 || dataGridViewIns.Rows.Count == 0 || dataGridViewIns.CurrentRow.Index < 0)
                return;

            var fila = dataGridViewIns.SelectedRows[0];
            Instituto? institutoSeleccionado = fila.DataBoundItem as Instituto;
            string title = "Eliminación de institutos";
            if (institutoSeleccionado == null)
            {
                MessageBox.Show("Ocurrió un error al intentar borrar el instituto seleccionado.", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // TODO validar que NO posea pagos pendientes a sus prestadores
            var result = MessageBox.Show($"Seguro que quiere borrar al instituto '{institutoSeleccionado}'", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result.Equals(DialogResult.Yes))
            {
                _institutos.Remove(institutoSeleccionado);
                RefreshDataGrid(dataGridViewIns, _institutos);
                if (dataGridViewIns.Rows.Count == 0)
                {
                    txtInsSeleccionado.Text = "";
                    btnInsModificar.Enabled = false;
                    btnInsBorrar.Enabled = false;
                    hayInstitutoSeleccionado = false;

                    btnInsProAsignarPrestador.Enabled = hayInstitutoSeleccionado && hayProveedorSeleccionado;
                    btnInsProGenerarPago.Enabled = hayInstitutoSeleccionado && hayProveedorSeleccionado;
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
            RefreshDataGrid(dataGridViewPro, _proveedores);
        }

        private void btnProModificar_Click(object sender, EventArgs e)
        {
            if (dataGridViewPro.CurrentRow == null || dataGridViewPro.SelectedRows.Count == 0 || dataGridViewPro.Rows.Count == 0 || dataGridViewPro.CurrentRow.Index < 0)
                return;

            var fila = dataGridViewPro.SelectedRows[0];
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
            RefreshDataGrid(dataGridViewPro, _proveedores);
        }

        private void btnProBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridViewPro.CurrentRow == null || dataGridViewPro.SelectedRows.Count == 0 || dataGridViewPro.Rows.Count == 0 || dataGridViewPro.CurrentRow.Index < 0)
                return;

            var fila = dataGridViewPro.SelectedRows[0];
            Proveedor? proveedorSeleccionado = fila.DataBoundItem as Proveedor;
            string title = "Eliminación de proveedores";
            if (proveedorSeleccionado == null)
            {
                MessageBox.Show("Ocurrió un error al intentar borrar el proveedor seleccionado.", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // TODO validar que NO tenga institutos asignados.

            var result = MessageBox.Show($"Seguro que quiere borrar al proveedor '{proveedorSeleccionado}'", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result.Equals(DialogResult.Yes))
            {
                _proveedores.Remove(proveedorSeleccionado);
                RefreshDataGrid(dataGridViewPro, _proveedores);
                if (dataGridViewPro.Rows.Count == 0)
                {
                    txtProSeleccionado.Text = "";
                    btnProModificar.Enabled = false;
                    btnProBorrar.Enabled = false;
                    hayProveedorSeleccionado = false;

                    btnInsProAsignarPrestador.Enabled = hayInstitutoSeleccionado && hayProveedorSeleccionado;
                    btnInsProGenerarPago.Enabled = hayInstitutoSeleccionado && hayProveedorSeleccionado;
                }
            }
        }
        #endregion

        private void btnInsProAsignarPrestador_Click(object sender, EventArgs e)
        {
            if (dataGridViewIns.CurrentRow == null || dataGridViewIns.SelectedRows.Count == 0 || dataGridViewIns.Rows.Count == 0 || dataGridViewIns.CurrentRow.Index < 0)
            {
                MessageBox.Show($"Ocurrió un error en la grilla de institutos al momento de la asignación.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dataGridViewPro.CurrentRow == null || dataGridViewPro.SelectedRows.Count == 0 || dataGridViewPro.Rows.Count == 0 || dataGridViewPro.CurrentRow.Index < 0)
            {
                MessageBox.Show($"Ocurrió un error en la grilla de proveedores al momento de la asignación.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // tomar institutoSeleccionado y proveedorSeleccionado
            var filaInstituto = dataGridViewIns.SelectedRows[0];
            Instituto? institutoSeleccionado = filaInstituto.DataBoundItem as Instituto;
            var filaProveedor = dataGridViewPro.SelectedRows[0];
            Proveedor? proveedorSeleccionado = filaProveedor.DataBoundItem as Proveedor;

            // Validar que NO se encuentre ya asignado
            var yaSeEncuentraAsignado = institutoSeleccionado.Proveedores.Any(p => p.Codigo == proveedorSeleccionado.Codigo);
            if (yaSeEncuentraAsignado)
            {
                MessageBox.Show($"No se puede volver a asignar el proveedor '{proveedorSeleccionado}' al instituto {institutoSeleccionado}.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // asignar
            institutoSeleccionado.Proveedores.Add(proveedorSeleccionado);

            // refrescar grillas 3 y 4
            RefreshDetailDataGrids(institutoSeleccionado, proveedorSeleccionado);
        }

        private void btnInsProGenerarPago_Click(object sender, EventArgs e)
        {

        }
    }
}
