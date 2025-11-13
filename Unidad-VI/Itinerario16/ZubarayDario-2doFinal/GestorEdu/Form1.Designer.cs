namespace GestorEdu
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            lblInstitutoSeleccionado1 = new Label();
            lblProveedoresAsociados = new Label();
            dgvProveedoresAsociados = new DataGridView();
            dgvInstitutos = new DataGridView();
            btnInsBorrar = new Button();
            btnInsModificar = new Button();
            btnInsNuevo = new Button();
            btnInsProAsignarPrestador = new Button();
            groupBox2 = new GroupBox();
            lblProveedorSeleccionado1 = new Label();
            lblInstitutosAsociados = new Label();
            dgvInstitutosAsociados = new DataGridView();
            dgvProveedores = new DataGridView();
            btnProBorrar = new Button();
            btnProModificar = new Button();
            btnProNuevo = new Button();
            btnInsProGenerarPago = new Button();
            lblIns = new Label();
            lblPro = new Label();
            txtInsSeleccionado = new TextBox();
            txtProSeleccionado = new TextBox();
            groupBox3 = new GroupBox();
            lblPagos = new Label();
            lblPagosInstitutoProveedor = new Label();
            dgvPagos = new DataGridView();
            dgvPagosInstitutosProveedores = new DataGridView();
            groupBox4 = new GroupBox();
            btnPagar = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProveedoresAsociados).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvInstitutos).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInstitutosAsociados).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPagos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPagosInstitutosProveedores).BeginInit();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblInstitutoSeleccionado1);
            groupBox1.Controls.Add(lblProveedoresAsociados);
            groupBox1.Controls.Add(dgvProveedoresAsociados);
            groupBox1.Controls.Add(dgvInstitutos);
            groupBox1.Controls.Add(btnInsBorrar);
            groupBox1.Controls.Add(btnInsModificar);
            groupBox1.Controls.Add(btnInsNuevo);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(600, 745);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Institutos";
            // 
            // lblInstitutoSeleccionado1
            // 
            lblInstitutoSeleccionado1.AutoSize = true;
            lblInstitutoSeleccionado1.Location = new Point(330, 378);
            lblInstitutoSeleccionado1.Name = "lblInstitutoSeleccionado1";
            lblInstitutoSeleccionado1.Size = new Size(0, 20);
            lblInstitutoSeleccionado1.TabIndex = 6;
            // 
            // lblProveedoresAsociados
            // 
            lblProveedoresAsociados.AutoSize = true;
            lblProveedoresAsociados.Font = new Font("Segoe UI", 10F);
            lblProveedoresAsociados.Location = new Point(10, 375);
            lblProveedoresAsociados.Name = "lblProveedoresAsociados";
            lblProveedoresAsociados.Size = new Size(329, 23);
            lblProveedoresAsociados.TabIndex = 5;
            lblProveedoresAsociados.Text = "Prestadores que trabajan con el instituto: ";
            // 
            // dgvProveedoresAsociados
            // 
            dgvProveedoresAsociados.AllowUserToAddRows = false;
            dgvProveedoresAsociados.AllowUserToDeleteRows = false;
            dgvProveedoresAsociados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProveedoresAsociados.Location = new Point(4, 416);
            dgvProveedoresAsociados.Name = "dgvProveedoresAsociados";
            dgvProveedoresAsociados.ReadOnly = true;
            dgvProveedoresAsociados.RowHeadersWidth = 51;
            dgvProveedoresAsociados.Size = new Size(590, 323);
            dgvProveedoresAsociados.TabIndex = 4;
            // 
            // dgvInstitutos
            // 
            dgvInstitutos.AllowUserToAddRows = false;
            dgvInstitutos.AllowUserToDeleteRows = false;
            dgvInstitutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInstitutos.Location = new Point(6, 67);
            dgvInstitutos.Name = "dgvInstitutos";
            dgvInstitutos.ReadOnly = true;
            dgvInstitutos.RowHeadersWidth = 51;
            dgvInstitutos.Size = new Size(588, 287);
            dgvInstitutos.TabIndex = 3;
            dgvInstitutos.SelectionChanged += dataGridViewIns_SelectionChanged;
            // 
            // btnInsBorrar
            // 
            btnInsBorrar.Enabled = false;
            btnInsBorrar.Location = new Point(360, 26);
            btnInsBorrar.Name = "btnInsBorrar";
            btnInsBorrar.Size = new Size(120, 35);
            btnInsBorrar.TabIndex = 2;
            btnInsBorrar.Text = "Borrar";
            btnInsBorrar.UseVisualStyleBackColor = true;
            btnInsBorrar.Click += btnInsBorrar_Click;
            // 
            // btnInsModificar
            // 
            btnInsModificar.Enabled = false;
            btnInsModificar.Location = new Point(234, 26);
            btnInsModificar.Name = "btnInsModificar";
            btnInsModificar.Size = new Size(120, 35);
            btnInsModificar.TabIndex = 1;
            btnInsModificar.Text = "Modificar";
            btnInsModificar.UseVisualStyleBackColor = true;
            btnInsModificar.Click += btnInsModificar_Click;
            // 
            // btnInsNuevo
            // 
            btnInsNuevo.Location = new Point(108, 26);
            btnInsNuevo.Name = "btnInsNuevo";
            btnInsNuevo.Size = new Size(120, 35);
            btnInsNuevo.TabIndex = 0;
            btnInsNuevo.Text = "Nuevo";
            btnInsNuevo.UseVisualStyleBackColor = true;
            btnInsNuevo.Click += btnInsNuevo_Click;
            // 
            // btnInsProAsignarPrestador
            // 
            btnInsProAsignarPrestador.Enabled = false;
            btnInsProAsignarPrestador.Location = new Point(119, 111);
            btnInsProAsignarPrestador.Name = "btnInsProAsignarPrestador";
            btnInsProAsignarPrestador.Size = new Size(158, 35);
            btnInsProAsignarPrestador.TabIndex = 4;
            btnInsProAsignarPrestador.Text = "Asignar Prestador";
            btnInsProAsignarPrestador.UseVisualStyleBackColor = true;
            btnInsProAsignarPrestador.Click += btnInsProAsignarPrestador_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblProveedorSeleccionado1);
            groupBox2.Controls.Add(lblInstitutosAsociados);
            groupBox2.Controls.Add(dgvInstitutosAsociados);
            groupBox2.Controls.Add(dgvProveedores);
            groupBox2.Controls.Add(btnProBorrar);
            groupBox2.Controls.Add(btnProModificar);
            groupBox2.Controls.Add(btnProNuevo);
            groupBox2.Location = new Point(618, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(600, 745);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Proveedores";
            // 
            // lblProveedorSeleccionado1
            // 
            lblProveedorSeleccionado1.AutoSize = true;
            lblProveedorSeleccionado1.Location = new Point(300, 378);
            lblProveedorSeleccionado1.Name = "lblProveedorSeleccionado1";
            lblProveedorSeleccionado1.Size = new Size(0, 20);
            lblProveedorSeleccionado1.TabIndex = 7;
            // 
            // lblInstitutosAsociados
            // 
            lblInstitutosAsociados.AutoSize = true;
            lblInstitutosAsociados.Font = new Font("Segoe UI", 10F);
            lblInstitutosAsociados.Location = new Point(6, 375);
            lblInstitutosAsociados.Name = "lblInstitutosAsociados";
            lblInstitutosAsociados.Size = new Size(299, 23);
            lblInstitutosAsociados.TabIndex = 6;
            lblInstitutosAsociados.Text = "Institutos que contratan al prestador: ";
            // 
            // dgvInstitutosAsociados
            // 
            dgvInstitutosAsociados.AllowUserToAddRows = false;
            dgvInstitutosAsociados.AllowUserToDeleteRows = false;
            dgvInstitutosAsociados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInstitutosAsociados.Location = new Point(6, 416);
            dgvInstitutosAsociados.Name = "dgvInstitutosAsociados";
            dgvInstitutosAsociados.ReadOnly = true;
            dgvInstitutosAsociados.RowHeadersWidth = 51;
            dgvInstitutosAsociados.Size = new Size(588, 323);
            dgvInstitutosAsociados.TabIndex = 4;
            // 
            // dgvProveedores
            // 
            dgvProveedores.AllowUserToAddRows = false;
            dgvProveedores.AllowUserToDeleteRows = false;
            dgvProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProveedores.Location = new Point(6, 67);
            dgvProveedores.Name = "dgvProveedores";
            dgvProveedores.ReadOnly = true;
            dgvProveedores.RowHeadersWidth = 51;
            dgvProveedores.Size = new Size(588, 287);
            dgvProveedores.TabIndex = 3;
            dgvProveedores.SelectionChanged += dataGridViewPro_SelectionChanged;
            // 
            // btnProBorrar
            // 
            btnProBorrar.Enabled = false;
            btnProBorrar.Location = new Point(377, 26);
            btnProBorrar.Name = "btnProBorrar";
            btnProBorrar.Size = new Size(120, 35);
            btnProBorrar.TabIndex = 2;
            btnProBorrar.Text = "Borrar";
            btnProBorrar.UseVisualStyleBackColor = true;
            btnProBorrar.Click += btnProBorrar_Click;
            // 
            // btnProModificar
            // 
            btnProModificar.Enabled = false;
            btnProModificar.Location = new Point(251, 26);
            btnProModificar.Name = "btnProModificar";
            btnProModificar.Size = new Size(120, 35);
            btnProModificar.TabIndex = 1;
            btnProModificar.Text = "Modificar";
            btnProModificar.UseVisualStyleBackColor = true;
            btnProModificar.Click += btnProModificar_Click;
            // 
            // btnProNuevo
            // 
            btnProNuevo.Location = new Point(125, 26);
            btnProNuevo.Name = "btnProNuevo";
            btnProNuevo.Size = new Size(120, 35);
            btnProNuevo.TabIndex = 0;
            btnProNuevo.Text = "Nuevo";
            btnProNuevo.UseVisualStyleBackColor = true;
            btnProNuevo.Click += btnProNuevo_Click;
            // 
            // btnInsProGenerarPago
            // 
            btnInsProGenerarPago.Enabled = false;
            btnInsProGenerarPago.Location = new Point(442, 111);
            btnInsProGenerarPago.Name = "btnInsProGenerarPago";
            btnInsProGenerarPago.Size = new Size(158, 35);
            btnInsProGenerarPago.TabIndex = 2;
            btnInsProGenerarPago.Text = "Generar Pago";
            btnInsProGenerarPago.UseVisualStyleBackColor = true;
            btnInsProGenerarPago.Click += btnInsProGenerarPago_Click;
            // 
            // lblIns
            // 
            lblIns.AutoSize = true;
            lblIns.Location = new Point(19, 48);
            lblIns.Name = "lblIns";
            lblIns.Size = new Size(70, 20);
            lblIns.TabIndex = 3;
            lblIns.Text = "Instituto: ";
            // 
            // lblPro
            // 
            lblPro.AutoSize = true;
            lblPro.Location = new Point(19, 81);
            lblPro.Name = "lblPro";
            lblPro.Size = new Size(80, 20);
            lblPro.TabIndex = 4;
            lblPro.Text = "Proveedor:";
            // 
            // txtInsSeleccionado
            // 
            txtInsSeleccionado.Location = new Point(119, 45);
            txtInsSeleccionado.Name = "txtInsSeleccionado";
            txtInsSeleccionado.ReadOnly = true;
            txtInsSeleccionado.RightToLeft = RightToLeft.Yes;
            txtInsSeleccionado.Size = new Size(481, 27);
            txtInsSeleccionado.TabIndex = 5;
            // 
            // txtProSeleccionado
            // 
            txtProSeleccionado.Location = new Point(119, 78);
            txtProSeleccionado.Name = "txtProSeleccionado";
            txtProSeleccionado.ReadOnly = true;
            txtProSeleccionado.RightToLeft = RightToLeft.Yes;
            txtProSeleccionado.Size = new Size(481, 27);
            txtProSeleccionado.TabIndex = 6;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnPagar);
            groupBox3.Controls.Add(lblPagos);
            groupBox3.Controls.Add(lblPagosInstitutoProveedor);
            groupBox3.Controls.Add(dgvPagos);
            groupBox3.Controls.Add(dgvPagosInstitutosProveedores);
            groupBox3.Location = new Point(1224, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(600, 745);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Pagos";
            // 
            // lblPagos
            // 
            lblPagos.AutoSize = true;
            lblPagos.Font = new Font("Segoe UI", 10F);
            lblPagos.Location = new Point(6, 375);
            lblPagos.Name = "lblPagos";
            lblPagos.Size = new Size(135, 23);
            lblPagos.TabIndex = 8;
            lblPagos.Text = "Todos los pagos:";
            // 
            // lblPagosInstitutoProveedor
            // 
            lblPagosInstitutoProveedor.AutoSize = true;
            lblPagosInstitutoProveedor.Font = new Font("Segoe UI", 10F);
            lblPagosInstitutoProveedor.Location = new Point(6, 31);
            lblPagosInstitutoProveedor.Name = "lblPagosInstitutoProveedor";
            lblPagosInstitutoProveedor.Size = new Size(246, 23);
            lblPagosInstitutoProveedor.TabIndex = 7;
            lblPagosInstitutoProveedor.Text = "Pagos del instituto y prestador:";
            // 
            // dgvPagos
            // 
            dgvPagos.AllowUserToAddRows = false;
            dgvPagos.AllowUserToDeleteRows = false;
            dgvPagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPagos.Location = new Point(6, 416);
            dgvPagos.Name = "dgvPagos";
            dgvPagos.ReadOnly = true;
            dgvPagos.RowHeadersWidth = 51;
            dgvPagos.Size = new Size(588, 323);
            dgvPagos.TabIndex = 1;
            // 
            // dgvPagosInstitutosProveedores
            // 
            dgvPagosInstitutosProveedores.AllowUserToAddRows = false;
            dgvPagosInstitutosProveedores.AllowUserToDeleteRows = false;
            dgvPagosInstitutosProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPagosInstitutosProveedores.Location = new Point(6, 67);
            dgvPagosInstitutosProveedores.Name = "dgvPagosInstitutosProveedores";
            dgvPagosInstitutosProveedores.ReadOnly = true;
            dgvPagosInstitutosProveedores.RowHeadersWidth = 51;
            dgvPagosInstitutosProveedores.Size = new Size(588, 287);
            dgvPagosInstitutosProveedores.TabIndex = 0;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(txtInsSeleccionado);
            groupBox4.Controls.Add(btnInsProGenerarPago);
            groupBox4.Controls.Add(btnInsProAsignarPrestador);
            groupBox4.Controls.Add(lblIns);
            groupBox4.Controls.Add(txtProSeleccionado);
            groupBox4.Controls.Add(lblPro);
            groupBox4.Location = new Point(12, 763);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(1812, 162);
            groupBox4.TabIndex = 8;
            groupBox4.TabStop = false;
            groupBox4.Text = "Asignación";
            // 
            // btnPagar
            // 
            btnPagar.Enabled = false;
            btnPagar.Location = new Point(441, 26);
            btnPagar.Name = "btnPagar";
            btnPagar.Size = new Size(153, 35);
            btnPagar.TabIndex = 7;
            btnPagar.Text = "Pagar";
            btnPagar.UseVisualStyleBackColor = true;
            btnPagar.Click += btnPagar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1837, 937);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "GestorEdu";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProveedoresAsociados).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvInstitutos).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInstitutosAsociados).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPagos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPagosInstitutosProveedores).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btnInsBorrar;
        private Button btnInsModificar;
        private Button btnInsNuevo;
        private Button btnProBorrar;
        private Button btnProModificar;
        private Button btnProNuevo;
        private DataGridView dgvInstitutos;
        private DataGridView dgvProveedores;
        private Button btnInsProAsignarPrestador;
        private Button btnInsProGenerarPago;
        private Label lblIns;
        private Label lblPro;
        private TextBox txtInsSeleccionado;
        private TextBox txtProSeleccionado;
        private DataGridView dgvProveedoresAsociados;
        private DataGridView dgvInstitutosAsociados;
        private Label lblProveedoresAsociados;
        private Label lblInstitutosAsociados;
        private GroupBox groupBox3;
        private DataGridView dgvPagos;
        private DataGridView dgvPagosInstitutosProveedores;
        private GroupBox groupBox4;
        private Label lblPagosInstitutoProveedor;
        private Label lblPagos;
        private Button btnPagar;
        private Label lblInstitutoSeleccionado1;
        private Label lblProveedorSeleccionado1;
    }
}
