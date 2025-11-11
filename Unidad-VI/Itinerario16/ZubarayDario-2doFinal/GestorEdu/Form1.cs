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

        private void dataGridViewIns_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewIns.SelectedRows.Count == 0 || dataGridViewIns.CurrentRow == null)
                return;

            if (dataGridViewIns.CurrentRow.Index < 0)
                return;

            var fila = dataGridViewIns.SelectedRows[0];
            var institutoSeleccionado = fila.DataBoundItem as Instituto;
            txtInsSeleccionado.Text = institutoSeleccionado?.Nombre;

            btnInsModificar.Enabled = true;
            btnInsBorrar.Enabled = true;
            hayInstitutoSeleccionado = true;

            btnInsProAsignarPrestador.Enabled = hayInstitutoSeleccionado && hayProveedorSeleccionado;
            btnInsProGenerarPago.Enabled = hayInstitutoSeleccionado && hayProveedorSeleccionado;
        }

        private void dataGridViewPro_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewPro.SelectedRows.Count == 0 || dataGridViewPro.CurrentRow == null)
                return;

            if (dataGridViewPro.CurrentRow.Index < 0)
                return;

            btnProModificar.Enabled = true;
            btnProBorrar.Enabled = true;
            hayProveedorSeleccionado = true;

            var fila = dataGridViewPro.SelectedRows[0];
            var proveedorSeleccionado = fila.DataBoundItem as Proveedor;
            txtProSeleccionado.Text = proveedorSeleccionado?.NombreORazonSocial;

            btnInsProAsignarPrestador.Enabled = hayInstitutoSeleccionado && true;
            btnInsProGenerarPago.Enabled = hayInstitutoSeleccionado && true;
        }


        #region Botones Instituto
        private void btnInsNuevo_Click(object sender, EventArgs e)
        {
            string title = "Registro de institutos";
            string codigo = Interaction.InputBox("Ingrese Codigo:", title, "").Trim();
            string nombre = Interaction.InputBox("Ingrese Nombre:", title, "").Trim();
            string telefono = Interaction.InputBox("Ingrese Teléfono:", title, "").Trim();
            string direccion = Interaction.InputBox("Ingrese Direccion:", title, "").Trim();

            // TODO: Validaciones

            var nuevoInstituto = new Instituto(codigo, nombre, telefono, direccion);

            _institutos.Add(nuevoInstituto);
            RefreshDataGrid(dataGridViewIns, _institutos);
        }

        private void btnInsModificar_Click(object sender, EventArgs e)
        {

        }

        private void btnInsBorrar_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Botones Proveedores
        private void btnProNuevo_Click(object sender, EventArgs e)
        {
            string title = "Registro de proveedores";
            string codigo = Interaction.InputBox("Ingrese Codigo:", title, "").Trim();
            string nombre = Interaction.InputBox("Ingrese Nombre:", title, "").Trim();
            string telefono = Interaction.InputBox("Ingrese Teléfono:", title, "").Trim();

            // TODO: Validaciones

            var nuevoProveedor = new Proveedor(codigo, nombre, telefono);

            _proveedores.Add(nuevoProveedor);
            RefreshDataGrid(dataGridViewPro, _proveedores);
        }

        private void btnProModificar_Click(object sender, EventArgs e)
        {

        }

        private void btnProBorrar_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
