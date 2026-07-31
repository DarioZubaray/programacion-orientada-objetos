namespace GestorEdu.Components
{
    partial class FormTipoPago
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbTipoPago = new ComboBox();
            btnAceptar = new Button();
            label1 = new Label();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // cmbTipoPago
            // 
            cmbTipoPago.FormattingEnabled = true;
            cmbTipoPago.Location = new Point(129, 75);
            cmbTipoPago.Name = "cmbTipoPago";
            cmbTipoPago.Size = new Size(220, 28);
            cmbTipoPago.TabIndex = 0;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(129, 129);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(94, 29);
            btnAceptar.TabIndex = 1;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 78);
            label1.Name = "label1";
            label1.Size = new Size(100, 20);
            label1.TabIndex = 2;
            label1.Text = "Tipo de Pago:";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(255, 129);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormTipoPago
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(402, 203);
            Controls.Add(btnCancelar);
            Controls.Add(label1);
            Controls.Add(btnAceptar);
            Controls.Add(cmbTipoPago);
            Name = "FormTipoPago";
            Text = "FormTipoPago";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbTipoPago;
        private Button btnAceptar;
        private Label label1;
        private Button btnCancelar;
    }
}