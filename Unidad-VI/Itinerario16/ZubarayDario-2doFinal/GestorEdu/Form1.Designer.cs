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
            dataGridViewPrestadoresInstituto = new DataGridView();
            dataGridViewIns = new DataGridView();
            btnInsBorrar = new Button();
            btnInsModificar = new Button();
            btnInsNuevo = new Button();
            btnInsProAsignarPrestador = new Button();
            groupBox2 = new GroupBox();
            dataGridViewInstitutoProveedores = new DataGridView();
            dataGridViewPro = new DataGridView();
            btnProBorrar = new Button();
            btnProModificar = new Button();
            btnProNuevo = new Button();
            btnInsProGenerarPago = new Button();
            label1 = new Label();
            label2 = new Label();
            txtInsSeleccionado = new TextBox();
            txtProSeleccionado = new TextBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPrestadoresInstituto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewIns).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewInstitutoProveedores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPro).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGridViewPrestadoresInstituto);
            groupBox1.Controls.Add(dataGridViewIns);
            groupBox1.Controls.Add(btnInsBorrar);
            groupBox1.Controls.Add(btnInsModificar);
            groupBox1.Controls.Add(btnInsNuevo);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(600, 700);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Institutos";
            // 
            // dataGridViewPrestadoresInstituto
            // 
            dataGridViewPrestadoresInstituto.AllowUserToAddRows = false;
            dataGridViewPrestadoresInstituto.AllowUserToDeleteRows = false;
            dataGridViewPrestadoresInstituto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPrestadoresInstituto.Location = new Point(4, 371);
            dataGridViewPrestadoresInstituto.Name = "dataGridViewPrestadoresInstituto";
            dataGridViewPrestadoresInstituto.ReadOnly = true;
            dataGridViewPrestadoresInstituto.RowHeadersWidth = 51;
            dataGridViewPrestadoresInstituto.Size = new Size(590, 323);
            dataGridViewPrestadoresInstituto.TabIndex = 4;
            // 
            // dataGridViewIns
            // 
            dataGridViewIns.AllowUserToAddRows = false;
            dataGridViewIns.AllowUserToDeleteRows = false;
            dataGridViewIns.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewIns.Location = new Point(6, 67);
            dataGridViewIns.Name = "dataGridViewIns";
            dataGridViewIns.ReadOnly = true;
            dataGridViewIns.RowHeadersWidth = 51;
            dataGridViewIns.Size = new Size(588, 287);
            dataGridViewIns.TabIndex = 3;
            dataGridViewIns.SelectionChanged += dataGridViewIns_SelectionChanged;
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
            btnInsProAsignarPrestador.Location = new Point(22, 792);
            btnInsProAsignarPrestador.Name = "btnInsProAsignarPrestador";
            btnInsProAsignarPrestador.Size = new Size(148, 35);
            btnInsProAsignarPrestador.TabIndex = 4;
            btnInsProAsignarPrestador.Text = "Asignar Prestador";
            btnInsProAsignarPrestador.UseVisualStyleBackColor = true;
            btnInsProAsignarPrestador.Click += btnInsProAsignarPrestador_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridViewInstitutoProveedores);
            groupBox2.Controls.Add(dataGridViewPro);
            groupBox2.Controls.Add(btnProBorrar);
            groupBox2.Controls.Add(btnProModificar);
            groupBox2.Controls.Add(btnProNuevo);
            groupBox2.Location = new Point(618, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(600, 700);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Proveedores";
            // 
            // dataGridViewInstitutoProveedores
            // 
            dataGridViewInstitutoProveedores.AllowUserToAddRows = false;
            dataGridViewInstitutoProveedores.AllowUserToDeleteRows = false;
            dataGridViewInstitutoProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewInstitutoProveedores.Location = new Point(6, 371);
            dataGridViewInstitutoProveedores.Name = "dataGridViewInstitutoProveedores";
            dataGridViewInstitutoProveedores.ReadOnly = true;
            dataGridViewInstitutoProveedores.RowHeadersWidth = 51;
            dataGridViewInstitutoProveedores.Size = new Size(588, 323);
            dataGridViewInstitutoProveedores.TabIndex = 4;
            // 
            // dataGridViewPro
            // 
            dataGridViewPro.AllowUserToAddRows = false;
            dataGridViewPro.AllowUserToDeleteRows = false;
            dataGridViewPro.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPro.Location = new Point(6, 67);
            dataGridViewPro.Name = "dataGridViewPro";
            dataGridViewPro.ReadOnly = true;
            dataGridViewPro.RowHeadersWidth = 51;
            dataGridViewPro.Size = new Size(588, 287);
            dataGridViewPro.TabIndex = 3;
            dataGridViewPro.SelectionChanged += dataGridViewPro_SelectionChanged;
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
            btnInsProGenerarPago.Location = new Point(176, 792);
            btnInsProGenerarPago.Name = "btnInsProGenerarPago";
            btnInsProGenerarPago.Size = new Size(120, 35);
            btnInsProGenerarPago.TabIndex = 2;
            btnInsProGenerarPago.Text = "Generar Pago";
            btnInsProGenerarPago.UseVisualStyleBackColor = true;
            btnInsProGenerarPago.Click += btnInsProGenerarPago_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 726);
            label1.Name = "label1";
            label1.Size = new Size(70, 20);
            label1.TabIndex = 3;
            label1.Text = "Instituto: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 756);
            label2.Name = "label2";
            label2.Size = new Size(80, 20);
            label2.TabIndex = 4;
            label2.Text = "Proveedor:";
            // 
            // txtInsSeleccionado
            // 
            txtInsSeleccionado.Location = new Point(120, 726);
            txtInsSeleccionado.Name = "txtInsSeleccionado";
            txtInsSeleccionado.ReadOnly = true;
            txtInsSeleccionado.RightToLeft = RightToLeft.Yes;
            txtInsSeleccionado.Size = new Size(428, 27);
            txtInsSeleccionado.TabIndex = 5;
            // 
            // txtProSeleccionado
            // 
            txtProSeleccionado.Location = new Point(120, 759);
            txtProSeleccionado.Name = "txtProSeleccionado";
            txtProSeleccionado.ReadOnly = true;
            txtProSeleccionado.RightToLeft = RightToLeft.Yes;
            txtProSeleccionado.Size = new Size(428, 27);
            txtProSeleccionado.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1230, 843);
            Controls.Add(btnInsProAsignarPrestador);
            Controls.Add(txtProSeleccionado);
            Controls.Add(txtInsSeleccionado);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnInsProGenerarPago);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "GestorEdu";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewPrestadoresInstituto).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewIns).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewInstitutoProveedores).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPro).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private DataGridView dataGridViewIns;
        private DataGridView dataGridViewPro;
        private Button btnInsProAsignarPrestador;
        private Button btnInsProGenerarPago;
        private Label label1;
        private Label label2;
        private TextBox txtInsSeleccionado;
        private TextBox txtProSeleccionado;
        private DataGridView dataGridViewPrestadoresInstituto;
        private DataGridView dataGridViewInstitutoProveedores;
    }
}
