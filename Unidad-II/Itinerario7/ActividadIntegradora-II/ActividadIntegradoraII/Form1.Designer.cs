namespace ActividadIntegradoraII
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
            dataGridViewInversores = new DataGridView();
            groupBoxInversores = new GroupBox();
            label1 = new Label();
            txtTotalInvertido = new TextBox();
            btnInversorBorrar = new Button();
            btnInversorModificar = new Button();
            btnInversorAgregar = new Button();
            groupBox1 = new GroupBox();
            btnVerConmisiones = new Button();
            btnAccionesBorrar = new Button();
            dataGridViewAcciones = new DataGridView();
            btnAccionesModificar = new Button();
            btnAccionesAgregar = new Button();
            groupBox2 = new GroupBox();
            lblVenta = new Label();
            lblCompra = new Label();
            btnMenos = new Button();
            txtCantidad = new TextBox();
            btnMas = new Button();
            dataGridViewCompraVenta = new DataGridView();
            btnVender = new Button();
            btnComprar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewInversores).BeginInit();
            groupBoxInversores.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAcciones).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCompraVenta).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewInversores
            // 
            dataGridViewInversores.AllowUserToAddRows = false;
            dataGridViewInversores.AllowUserToDeleteRows = false;
            dataGridViewInversores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewInversores.Location = new Point(6, 78);
            dataGridViewInversores.Name = "dataGridViewInversores";
            dataGridViewInversores.ReadOnly = true;
            dataGridViewInversores.RowHeadersWidth = 51;
            dataGridViewInversores.Size = new Size(588, 316);
            dataGridViewInversores.TabIndex = 0;
            dataGridViewInversores.SelectionChanged += dataGridViewInversores_SelectionChanged;
            // 
            // groupBoxInversores
            // 
            groupBoxInversores.Controls.Add(label1);
            groupBoxInversores.Controls.Add(txtTotalInvertido);
            groupBoxInversores.Controls.Add(btnInversorBorrar);
            groupBoxInversores.Controls.Add(btnInversorModificar);
            groupBoxInversores.Controls.Add(btnInversorAgregar);
            groupBoxInversores.Controls.Add(dataGridViewInversores);
            groupBoxInversores.Location = new Point(10, 5);
            groupBoxInversores.Name = "groupBoxInversores";
            groupBoxInversores.Size = new Size(599, 400);
            groupBoxInversores.TabIndex = 1;
            groupBoxInversores.TabStop = false;
            groupBoxInversores.Text = "Inversores";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(386, 33);
            label1.Name = "label1";
            label1.Size = new Size(117, 20);
            label1.TabIndex = 5;
            label1.Text = "Total Invertido $";
            // 
            // txtTotalInvertido
            // 
            txtTotalInvertido.Location = new Point(507, 31);
            txtTotalInvertido.Name = "txtTotalInvertido";
            txtTotalInvertido.ReadOnly = true;
            txtTotalInvertido.Size = new Size(87, 27);
            txtTotalInvertido.TabIndex = 4;
            txtTotalInvertido.Text = "0";
            txtTotalInvertido.TextAlign = HorizontalAlignment.Center;
            // 
            // btnInversorBorrar
            // 
            btnInversorBorrar.Location = new Point(260, 28);
            btnInversorBorrar.Name = "btnInversorBorrar";
            btnInversorBorrar.Size = new Size(120, 30);
            btnInversorBorrar.TabIndex = 3;
            btnInversorBorrar.Text = "Borrar";
            btnInversorBorrar.UseVisualStyleBackColor = true;
            btnInversorBorrar.Click += btnInversorBorrar_Click;
            // 
            // btnInversorModificar
            // 
            btnInversorModificar.Location = new Point(134, 28);
            btnInversorModificar.Name = "btnInversorModificar";
            btnInversorModificar.Size = new Size(120, 30);
            btnInversorModificar.TabIndex = 2;
            btnInversorModificar.Text = "Modificar";
            btnInversorModificar.UseVisualStyleBackColor = true;
            btnInversorModificar.Click += btnInversorModificar_Click;
            // 
            // btnInversorAgregar
            // 
            btnInversorAgregar.Location = new Point(8, 28);
            btnInversorAgregar.Name = "btnInversorAgregar";
            btnInversorAgregar.Size = new Size(120, 30);
            btnInversorAgregar.TabIndex = 1;
            btnInversorAgregar.Text = "Agregar";
            btnInversorAgregar.UseVisualStyleBackColor = true;
            btnInversorAgregar.Click += btnInversorAgregar_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnVerConmisiones);
            groupBox1.Controls.Add(btnAccionesBorrar);
            groupBox1.Controls.Add(dataGridViewAcciones);
            groupBox1.Controls.Add(btnAccionesModificar);
            groupBox1.Controls.Add(btnAccionesAgregar);
            groupBox1.Location = new Point(615, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(600, 400);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Acciones";
            // 
            // btnVerConmisiones
            // 
            btnVerConmisiones.Location = new Point(389, 28);
            btnVerConmisiones.Name = "btnVerConmisiones";
            btnVerConmisiones.Size = new Size(195, 30);
            btnVerConmisiones.TabIndex = 7;
            btnVerConmisiones.Text = "Ver Comisiones";
            btnVerConmisiones.UseVisualStyleBackColor = true;
            btnVerConmisiones.Click += btnVerComisiones_Click;
            // 
            // btnAccionesBorrar
            // 
            btnAccionesBorrar.Location = new Point(263, 28);
            btnAccionesBorrar.Name = "btnAccionesBorrar";
            btnAccionesBorrar.Size = new Size(120, 30);
            btnAccionesBorrar.TabIndex = 6;
            btnAccionesBorrar.Text = "Borrar";
            btnAccionesBorrar.UseVisualStyleBackColor = true;
            btnAccionesBorrar.Click += btnAccionesBorrar_Click;
            // 
            // dataGridViewAcciones
            // 
            dataGridViewAcciones.AllowUserToAddRows = false;
            dataGridViewAcciones.AllowUserToDeleteRows = false;
            dataGridViewAcciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAcciones.Location = new Point(6, 78);
            dataGridViewAcciones.Name = "dataGridViewAcciones";
            dataGridViewAcciones.ReadOnly = true;
            dataGridViewAcciones.RowHeadersWidth = 51;
            dataGridViewAcciones.Size = new Size(588, 316);
            dataGridViewAcciones.TabIndex = 0;
            dataGridViewAcciones.SelectionChanged += dataGridViewAcciones_SelectionChanged;
            // 
            // btnAccionesModificar
            // 
            btnAccionesModificar.Location = new Point(137, 28);
            btnAccionesModificar.Name = "btnAccionesModificar";
            btnAccionesModificar.Size = new Size(120, 30);
            btnAccionesModificar.TabIndex = 5;
            btnAccionesModificar.Text = "Modificar";
            btnAccionesModificar.UseVisualStyleBackColor = true;
            btnAccionesModificar.Click += btnAccionesModificar_Click;
            // 
            // btnAccionesAgregar
            // 
            btnAccionesAgregar.Location = new Point(11, 28);
            btnAccionesAgregar.Name = "btnAccionesAgregar";
            btnAccionesAgregar.Size = new Size(120, 30);
            btnAccionesAgregar.TabIndex = 4;
            btnAccionesAgregar.Text = "Agregar";
            btnAccionesAgregar.UseVisualStyleBackColor = true;
            btnAccionesAgregar.Click += btnAccionesAgregar_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblVenta);
            groupBox2.Controls.Add(lblCompra);
            groupBox2.Controls.Add(btnMenos);
            groupBox2.Controls.Add(txtCantidad);
            groupBox2.Controls.Add(btnMas);
            groupBox2.Controls.Add(dataGridViewCompraVenta);
            groupBox2.Controls.Add(btnVender);
            groupBox2.Controls.Add(btnComprar);
            groupBox2.Location = new Point(10, 411);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1205, 316);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Compra-Venta";
            // 
            // lblVenta
            // 
            lblVenta.AutoSize = true;
            lblVenta.Location = new Point(995, 26);
            lblVenta.Name = "lblVenta";
            lblVenta.Size = new Size(13, 20);
            lblVenta.TabIndex = 7;
            lblVenta.Text = " ";
            // 
            // lblCompra
            // 
            lblCompra.AutoSize = true;
            lblCompra.Location = new Point(134, 31);
            lblCompra.Name = "lblCompra";
            lblCompra.Size = new Size(13, 20);
            lblCompra.TabIndex = 6;
            lblCompra.Text = " ";
            // 
            // btnMenos
            // 
            btnMenos.Location = new Point(639, 26);
            btnMenos.Name = "btnMenos";
            btnMenos.Size = new Size(60, 30);
            btnMenos.TabIndex = 5;
            btnMenos.Text = "-";
            btnMenos.UseVisualStyleBackColor = true;
            btnMenos.Click += btnMenos_Click;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(573, 26);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(60, 27);
            txtCantidad.TabIndex = 4;
            txtCantidad.Text = "0";
            txtCantidad.TextAlign = HorizontalAlignment.Center;
            // 
            // btnMas
            // 
            btnMas.Location = new Point(507, 26);
            btnMas.Name = "btnMas";
            btnMas.Size = new Size(60, 30);
            btnMas.TabIndex = 3;
            btnMas.Text = "+";
            btnMas.UseVisualStyleBackColor = true;
            btnMas.Click += btnMas_Click;
            // 
            // dataGridViewCompraVenta
            // 
            dataGridViewCompraVenta.AllowUserToAddRows = false;
            dataGridViewCompraVenta.AllowUserToDeleteRows = false;
            dataGridViewCompraVenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCompraVenta.Location = new Point(6, 64);
            dataGridViewCompraVenta.Name = "dataGridViewCompraVenta";
            dataGridViewCompraVenta.ReadOnly = true;
            dataGridViewCompraVenta.RowHeadersWidth = 51;
            dataGridViewCompraVenta.Size = new Size(1193, 246);
            dataGridViewCompraVenta.TabIndex = 2;
            dataGridViewCompraVenta.SelectionChanged += dataGridViewCompraVenta_SelectionChanged;
            // 
            // btnVender
            // 
            btnVender.Location = new Point(869, 21);
            btnVender.Name = "btnVender";
            btnVender.Size = new Size(120, 30);
            btnVender.TabIndex = 1;
            btnVender.Text = "Vender";
            btnVender.UseVisualStyleBackColor = true;
            btnVender.Click += btnVender_Click;
            // 
            // btnComprar
            // 
            btnComprar.Location = new Point(8, 26);
            btnComprar.Name = "btnComprar";
            btnComprar.Size = new Size(120, 30);
            btnComprar.TabIndex = 0;
            btnComprar.Text = "Comprar";
            btnComprar.UseVisualStyleBackColor = true;
            btnComprar.Click += btnComprar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1220, 728);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(groupBoxInversores);
            Name = "Form1";
            Text = "Actividad Integradora Nro 2";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewInversores).EndInit();
            groupBoxInversores.ResumeLayout(false);
            groupBoxInversores.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewAcciones).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCompraVenta).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewInversores;
        private GroupBox groupBoxInversores;
        private Button btnInversorAgregar;
        private Button btnInversorModificar;
        private Button btnInversorBorrar;
        private GroupBox groupBox1;
        private DataGridView dataGridViewAcciones;
        private Button btnAccionesBorrar;
        private Button btnAccionesModificar;
        private Button btnAccionesAgregar;
        private GroupBox groupBox2;
        private Button btnVender;
        private Button btnComprar;
        private DataGridView dataGridViewCompraVenta;
        private TextBox txtCantidad;
        private Button btnMas;
        private Button btnMenos;
        private Label lblVenta;
        private Label lblCompra;
        private Label label1;
        private TextBox txtTotalInvertido;
        private Button btnVerConmisiones;
    }
}
