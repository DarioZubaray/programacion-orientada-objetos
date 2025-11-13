using GestorEdu.Components;
using GestorEdu.Entities;
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
            // Solo permite seleccionar una fila a la vez (no múltiples selecciones).
            dgv.MultiSelect = false;
            // Cambia el modo de selección para que al hacer clic en una celda se seleccione toda la fila completa.
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // Permite que el usuario NO cambie el orden de las columnas arrastrándolas con el mouse.
            dgv.AllowUserToOrderColumns = false;
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
                    .Select(x => new PagosView
                    {
                        InstitutoCodigo = x.Instituto.Codigo,
                        InstitutoNombre = x.Instituto.Nombre,
                        ProveedorCodigo = x.Proveedor.Codigo,
                        ProveedorNombre = x.Proveedor.NombreORazonSocial,
                        TipoPago = x.GetType().Name,
                        Importe = x.Importe.ToString(),
                        FechaVencimiento = x.FechaVencimiento.ToString()
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
                                Tipo = x.GetType().Name,
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
            // Validar grilla institutos este seleccionada y contenga datos
            if (dgvInstitutos.CurrentRow == null || dgvInstitutos.CurrentRow.Index < 0 || dgvInstitutos.SelectedRows.Count == 0 || dgvInstitutos.Rows.Count == 0)
                return;

            // Obtener la fila seleccionada como un objeto Instituto
            var fila = dgvInstitutos.SelectedRows[0];
            _institutoSeleccionado = fila.DataBoundItem as Instituto;
            if(_institutoSeleccionado == null)
            {
                btnInsModificar.Enabled = false;
                btnInsBorrar.Enabled = false;
                btnInsProAsignarPrestador.Enabled = false;
                btnInsProGenerarPago.Enabled = false;
                btnPagar.Enabled = false;
                return;
            }

            // habilitar los botones del ABM Instituto
            btnInsModificar.Enabled = true;
            btnInsBorrar.Enabled = true;

            // Informar en los labels el proveedor seleccionado
            lblInstitutoSeleccionado1.Text = _institutoSeleccionado.Nombre;
            txtInsSeleccionado.Text = _institutoSeleccionado.Nombre;
            var labelInstitutoProveedor = lblPagosInstitutoProveedor.Text;
            lblPagosInstitutoProveedor.Text = $"Pagos del instituto [{_institutoSeleccionado?.Nombre}] y prestador [{_proveedorSeleccionado?.NombreORazonSocial}]:";

            // Actualizar las Grillas 3 y 4
            RefreshDataGrid(dgvProveedoresAsociados, _institutoSeleccionado.Proveedores);
            RefreshDataGridInstitutosProveedoresPagos();

            // Habilitar los botones de asignacion
            if(_proveedorSeleccionado != null)
            {
                bool isProovedorAsigned = _institutoSeleccionado.Proveedores.Any(pro => pro.Codigo.Equals(_proveedorSeleccionado.Codigo));
                btnInsProAsignarPrestador.Enabled = !isProovedorAsigned;
                btnInsProGenerarPago.Enabled = isProovedorAsigned;

                btnPagar.Enabled = dgvPagos.SelectedRows.Count > 0;
            }
            else
            {
                btnInsProAsignarPrestador.Enabled = false;
                btnInsProGenerarPago.Enabled = false;
                btnPagar.Enabled = false;
            }
        }

        private void dataGridViewPro_SelectionChanged(object sender, EventArgs e)
        {
            // Validar grilla proveedores este seleccionada y contenga datos
            if (dgvProveedores.CurrentRow == null || dgvProveedores.CurrentRow.Index < 0 || dgvProveedores.SelectedRows.Count == 0 || dgvProveedores.Rows.Count == 0)
                return;

            // Obtener la fila seleccionada como un objeto Proveedor
            var fila = dgvProveedores.SelectedRows[0];
            _proveedorSeleccionado = fila.DataBoundItem as Proveedor;
            if(_proveedorSeleccionado == null)
            {
                btnProModificar.Enabled = false;
                btnProBorrar.Enabled = false;
                btnInsProAsignarPrestador.Enabled = false;
                btnInsProGenerarPago.Enabled = false;
                btnPagar.Enabled = false;
                return;
            }

            // habilitar los botones del ABM Proveedor
            btnProModificar.Enabled = true;
            btnProBorrar.Enabled = true;

            // Informar en los labels el proveedor seleccionado
            lblProveedorSeleccionado1.Text = _proveedorSeleccionado.NombreORazonSocial;
            txtProSeleccionado.Text = _proveedorSeleccionado.NombreORazonSocial;
            var labelInstitutoProveedor = lblPagosInstitutoProveedor.Text;
            lblPagosInstitutoProveedor.Text = $"Pagos del instituto [{_institutoSeleccionado?.Nombre}] y prestador [{_proveedorSeleccionado?.NombreORazonSocial}]:";

            // Actualizar Grillas 3 y 4
            RefreshDataGrid(dgvInstitutosAsociados,
                _institutos.Where(ins =>
                    ins.Proveedores.Any(p =>
                        p.Codigo.Equals(_proveedorSeleccionado.Codigo, StringComparison.OrdinalIgnoreCase)
                    )
                ).ToList());
            RefreshDataGridInstitutosProveedoresPagos();

            // Habilitar los botones de asignacion
            if (_institutoSeleccionado != null)
            {
                bool isInstitutoAsigned = _proveedorSeleccionado.Institutos.Any(ins => ins.Codigo.Equals(_institutoSeleccionado.Codigo));
                btnInsProAsignarPrestador.Enabled = !isInstitutoAsigned;
                btnInsProGenerarPago.Enabled = isInstitutoAsigned;

                btnPagar.Enabled = dgvPagos.SelectedRows.Count > 0;
            }
            else
            {
                btnInsProAsignarPrestador.Enabled = false;
                btnInsProGenerarPago.Enabled = false;
                btnPagar.Enabled = false;
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
            // Validar codigo unico
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
            if (string.IsNullOrWhiteSpace(direccion))
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
            _institutoSeleccionado = fila.DataBoundItem as Instituto;
            string title = "Modificación de institutos";
            if (_institutoSeleccionado == null)
            {
                MessageBox.Show("Ocurrió un error al modificar el instituto seleccionado.", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string nombre = Interaction.InputBox("Ingrese Nombre:", title, _institutoSeleccionado.Nombre).Trim();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El Nombre no puede estar vacío.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string telefono = Interaction.InputBox("Ingrese Teléfono:", title, _institutoSeleccionado.Telefono).Trim();
            if (string.IsNullOrWhiteSpace(telefono))
            {
                MessageBox.Show("El Teléfono no puede estar vacío.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string direccion = Interaction.InputBox("Ingrese Dirección:", title, _institutoSeleccionado.Direccion).Trim();
            if (string.IsNullOrWhiteSpace(direccion))
            {
                MessageBox.Show("La Dirección no puede estar vacía.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _institutoSeleccionado.Nombre = nombre;
            _institutoSeleccionado.Telefono = telefono;
            _institutoSeleccionado.Direccion = direccion;
            RefreshDataGrid(dgvInstitutos, _institutos);
        }

        private void btnInsBorrar_Click(object sender, EventArgs e)
        {
            if (dgvInstitutos.CurrentRow == null || dgvInstitutos.SelectedRows.Count == 0 || dgvInstitutos.Rows.Count == 0 || dgvInstitutos.CurrentRow.Index < 0)
                return;

            var fila = dgvInstitutos.SelectedRows[0];
            _institutoSeleccionado = fila.DataBoundItem as Instituto;
            string title = "Eliminación de institutos";
            if (_institutoSeleccionado == null)
            {
                MessageBox.Show("Ocurrió un error al intentar borrar el instituto seleccionado.", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // validar que NO posea pagos pendientes a sus prestadores
            var conPagos = _institutos.Where(ins => ins.Pagos.Any(p => p.Estado == EstadoPago.No_Cancelado)).ToList();
            if (conPagos.Count > 0)
            {
                MessageBox.Show($"No es posible borrar el instituto {_institutoSeleccionado} seleccionado, ya que posee pagos pendientes.", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show($"Seguro que quiere borrar al instituto '{_institutoSeleccionado}'", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result.Equals(DialogResult.Yes))
            {
                _institutos.Remove(_institutoSeleccionado);
                RefreshDataGrid(dgvInstitutos, _institutos);
                if (dgvInstitutos.Rows.Count == 0)
                {
                    txtInsSeleccionado.Text = "";
                    btnInsModificar.Enabled = false;
                    btnInsBorrar.Enabled = false;
                    btnInsProAsignarPrestador.Enabled = false;
                    btnInsProGenerarPago.Enabled = false;
                    btnInsNuevo.Focus();
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
            // Validar codigo unico
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
            _proveedorSeleccionado = fila.DataBoundItem as Proveedor;
            string title = "Modificación de proveedores";
            if (_proveedorSeleccionado == null)
            {
                MessageBox.Show("Ocurrió un error al modificar el proveedor seleccionado.", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string nombre = Interaction.InputBox("Ingrese Nombre o Razón Social:", title, _proveedorSeleccionado.NombreORazonSocial).Trim();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El Nombre o Razón Social no puede estar vacío.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string telefono = Interaction.InputBox("Ingrese Teléfono:", title, _proveedorSeleccionado.Telefono).Trim();
            if (string.IsNullOrWhiteSpace(telefono))
            {
                MessageBox.Show("El Teléfono no puede estar vacío.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _proveedorSeleccionado.NombreORazonSocial = nombre;
            _proveedorSeleccionado.Telefono = telefono;
            RefreshDataGrid(dgvProveedores, _proveedores);
        }

        private void btnProBorrar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.CurrentRow == null || dgvProveedores.SelectedRows.Count == 0 || dgvProveedores.Rows.Count == 0 || dgvProveedores.CurrentRow.Index < 0)
                return;

            var fila = dgvProveedores.SelectedRows[0];
            _proveedorSeleccionado = fila.DataBoundItem as Proveedor;
            string title = "Eliminación de proveedores";
            if (_proveedorSeleccionado == null)
            {
                MessageBox.Show("Ocurrió un error al intentar borrar el proveedor seleccionado.", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Validar que NO tenga institutos asignados
            if (_proveedorSeleccionado.Institutos.Count > 0)
            {
                MessageBox.Show($"El Proveedor '{_proveedorSeleccionado}' no puede ser eliminado ya que cuenta con Institutos asociados.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Validar que NO tenga pagos por cobrar
            if(_proveedorSeleccionado.Pagos.Any(p => p.Estado.Equals(EstadoPago.No_Cancelado)))
            {
                MessageBox.Show($"El Proveedor '{_proveedorSeleccionado}' tiene pagos pendiente por cobrar.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Seguro que quiere borrar al proveedor '{_proveedorSeleccionado}'", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result.Equals(DialogResult.Yes))
            {
                _proveedores.Remove(_proveedorSeleccionado);
                RefreshDataGrid(dgvProveedores, _proveedores);
                if (dgvProveedores.Rows.Count == 0)
                {
                    txtProSeleccionado.Text = "";
                    btnProModificar.Enabled = false;
                    btnProBorrar.Enabled = false;
                    btnInsProAsignarPrestador.Enabled = false;
                    btnInsProGenerarPago.Enabled = false;
                    btnProNuevo.Focus();
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
            _institutoSeleccionado = filaInstituto.DataBoundItem as Instituto;
            var filaProveedor = dgvProveedores.SelectedRows[0];
            _proveedorSeleccionado = filaProveedor.DataBoundItem as Proveedor;
            if(_institutoSeleccionado == null || _proveedorSeleccionado == null)
            {
                MessageBox.Show("Ocurrió un error al intentar asignar el proveedor al instituo, Intente más tarde.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Validar que NO se encuentre ya asignado
            var yaSeEncuentraAsignado = _institutoSeleccionado.Proveedores.Any(p => p.Codigo == _proveedorSeleccionado.Codigo);
            if (yaSeEncuentraAsignado)
            {
                MessageBox.Show($"No se puede volver a asignar el proveedor '{_proveedorSeleccionado}' al instituto {_institutoSeleccionado}.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // asignar
            _institutoSeleccionado.AsignarProveedor(_proveedorSeleccionado);

            // refrescar grillas 3 y 4
            RefreshDetailDataGrids(_institutoSeleccionado, _proveedorSeleccionado);

            // Activar como verdaro el boton de generar pago y deshabilitar el mismo
            btnInsProAsignarPrestador.Enabled = false;
            btnInsProGenerarPago.Enabled = true;
            btnInsProGenerarPago.Focus();
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
            _institutoSeleccionado = filaInstituto.DataBoundItem as Instituto;
            var filaProveedor = dgvProveedores.SelectedRows[0];
            _proveedorSeleccionado = filaProveedor.DataBoundItem as Proveedor;
            if (_institutoSeleccionado == null || _proveedorSeleccionado == null)
            {
                MessageBox.Show("Ocurrió un error al intentar asignar el proveedor al instituo, Intente más tarde.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

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

            // determinar tipo de pago
            string tipoPago = PagoTransferencia.TIPO;
            using (var form = new FormTipoPago())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    tipoPago = form.TipoPagoSeleccionado;
                }
            }

            _institutoSeleccionado.RegistrarPago(_proveedorSeleccionado, tipoPago, decimal.Parse(importe), fecha);
            RefreshDataGridInstitutosProveedoresPagos();
            RefreshPagosDataGrid();

            btnPagar.Enabled = true;
            btnPagar.Focus();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPagosInstitutosProveedores.SelectedRows.Count < 0)
                {
                    throw new Exception("Ocurrió un error al intentar obtener el pago asociado, Intente más tarde.");
                }
                var fila = dgvPagosInstitutosProveedores.SelectedRows[0];
                PagosView pagoSeleccionado = fila.DataBoundItem as PagosView;
                if (pagoSeleccionado == null)
                {
                    throw new Exception("Ocurrió un error al intentar obtener el pago asociado.");
                }

                // cargar institutoSeleccionado y proveedorSeleccionado
                _institutoSeleccionado = _institutos.Find(ins => ins.Codigo.Equals(pagoSeleccionado.InstitutoCodigo));
                _proveedorSeleccionado = _proveedores.Find(pro => pro.Codigo.Equals(pagoSeleccionado.ProveedorCodigo));
                if (_institutoSeleccionado == null || _proveedorSeleccionado == null)
                {
                    throw new Exception("Ocurrió un error al intentar obtener el proveedor y el instituo, Intente más tarde.");
                }

                Pago? pagoAsignado = _institutoSeleccionado.Pagos.Find(pago => pago.Instituto.Codigo.Equals(_institutoSeleccionado.Codigo) &&
                                                         pago.Proveedor.Codigo.Equals(_proveedorSeleccionado.Codigo));
                if (pagoAsignado != null && pagoAsignado.Estado.Equals(EstadoPago.No_Cancelado))
                {
                    pagoAsignado.Estado = EstadoPago.Cancelado;
                    pagoAsignado.ProcesarPago();
                    // Actualizando los datos de las Grillas 5 y 6
                    RefreshDataGridInstitutosProveedoresPagos();
                    RefreshPagosDataGrid();

                    MessageBox.Show("El pago se efectuado con éxito.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (pagoAsignado != null && pagoAsignado.Estado.Equals(EstadoPago.Cancelado))
                    return;
                else
                {
                    throw new Exception("Ocurrió un error al intentar obtener el pago asociado, Intente más tarde.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion
    }
}
