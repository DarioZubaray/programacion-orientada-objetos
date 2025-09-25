namespace GestionMembresia
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
            dataGridViewClientes = new DataGridView();
            btnClienteBorrar = new Button();
            btnClienteModificar = new Button();
            btnClienteAgregar = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewClientes).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGridViewClientes);
            groupBox1.Controls.Add(btnClienteBorrar);
            groupBox1.Controls.Add(btnClienteModificar);
            groupBox1.Controls.Add(btnClienteAgregar);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(720, 360);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Clientes";
            // 
            // dataGridViewClientes
            // 
            dataGridViewClientes.AllowUserToAddRows = false;
            dataGridViewClientes.AllowUserToDeleteRows = false;
            dataGridViewClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewClientes.Location = new Point(6, 62);
            dataGridViewClientes.Name = "dataGridViewClientes";
            dataGridViewClientes.ReadOnly = true;
            dataGridViewClientes.RowHeadersWidth = 51;
            dataGridViewClientes.Size = new Size(708, 292);
            dataGridViewClientes.TabIndex = 3;
            // 
            // btnClienteBorrar
            // 
            btnClienteBorrar.Location = new Point(218, 26);
            btnClienteBorrar.Name = "btnClienteBorrar";
            btnClienteBorrar.Size = new Size(100, 30);
            btnClienteBorrar.TabIndex = 2;
            btnClienteBorrar.Text = "Borrar";
            btnClienteBorrar.UseVisualStyleBackColor = true;
            btnClienteBorrar.Click += btnClienteBorrar_Click;
            // 
            // btnClienteModificar
            // 
            btnClienteModificar.Location = new Point(112, 26);
            btnClienteModificar.Name = "btnClienteModificar";
            btnClienteModificar.Size = new Size(100, 30);
            btnClienteModificar.TabIndex = 1;
            btnClienteModificar.Text = "Modificar";
            btnClienteModificar.UseVisualStyleBackColor = true;
            btnClienteModificar.Click += btnClienteModificar_Click;
            // 
            // btnClienteAgregar
            // 
            btnClienteAgregar.Location = new Point(6, 26);
            btnClienteAgregar.Name = "btnClienteAgregar";
            btnClienteAgregar.Size = new Size(100, 30);
            btnClienteAgregar.TabIndex = 0;
            btnClienteAgregar.Text = "Agregar";
            btnClienteAgregar.UseVisualStyleBackColor = true;
            btnClienteAgregar.Click += btnClienteAgregar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1062, 673);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Sistema de Gestion de Membresias en un Gimnasio";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewClientes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnClienteModificar;
        private Button btnClienteAgregar;
        private Button btnClienteBorrar;
        private DataGridView dataGridViewClientes;
    }
}
