using GestorEdu.Entities;

namespace GestorEdu.Components
{
    public partial class FormTipoPago : Form
    {
        public string TipoPagoSeleccionado { get; private set; }
        public FormTipoPago()
        {
            InitializeComponent();
            cmbTipoPago.Items.AddRange(new[] { PagoTransferencia.TIPO, PagoCheque.TIPO });
            cmbTipoPago.SelectedIndex = 0;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            TipoPagoSeleccionado = cmbTipoPago.SelectedItem.ToString();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            TipoPagoSeleccionado = PagoTransferencia.TIPO;
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
