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
            groupBox2 = new GroupBox();
            btnMembresiaBorrar = new Button();
            btnMembresiaModificar = new Button();
            btnMembresiaAgregar = new Button();
            dataGridViewMembresias = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewClientes).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMembresias).BeginInit();
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
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridViewMembresias);
            groupBox2.Controls.Add(btnMembresiaBorrar);
            groupBox2.Controls.Add(btnMembresiaModificar);
            groupBox2.Controls.Add(btnMembresiaAgregar);
            groupBox2.Location = new Point(738, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(676, 360);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Membresias";
            // 
            // btnMembresiaBorrar
            // 
            btnMembresiaBorrar.Location = new Point(218, 26);
            btnMembresiaBorrar.Name = "btnMembresiaBorrar";
            btnMembresiaBorrar.Size = new Size(100, 30);
            btnMembresiaBorrar.TabIndex = 5;
            btnMembresiaBorrar.Text = "Borrar";
            btnMembresiaBorrar.UseVisualStyleBackColor = true;
            btnMembresiaBorrar.Click += btnMembresiaBorrar_Click;
            // 
            // btnMembresiaModificar
            // 
            btnMembresiaModificar.Location = new Point(112, 26);
            btnMembresiaModificar.Name = "btnMembresiaModificar";
            btnMembresiaModificar.Size = new Size(100, 30);
            btnMembresiaModificar.TabIndex = 4;
            btnMembresiaModificar.Text = "Modificar";
            btnMembresiaModificar.UseVisualStyleBackColor = true;
            btnMembresiaModificar.Click += btnMembresiaModificar_Click;
            // 
            // btnMembresiaAgregar
            // 
            btnMembresiaAgregar.Location = new Point(6, 26);
            btnMembresiaAgregar.Name = "btnMembresiaAgregar";
            btnMembresiaAgregar.Size = new Size(100, 30);
            btnMembresiaAgregar.TabIndex = 3;
            btnMembresiaAgregar.Text = "Agregar";
            btnMembresiaAgregar.UseVisualStyleBackColor = true;
            btnMembresiaAgregar.Click += btnMembresiaAgregar_Click;
            // 
            // dataGridViewMembresias
            // 
            dataGridViewMembresias.AllowUserToAddRows = false;
            dataGridViewMembresias.AllowUserToDeleteRows = false;
            dataGridViewMembresias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMembresias.Location = new Point(6, 62);
            dataGridViewMembresias.Name = "dataGridViewMembresias";
            dataGridViewMembresias.ReadOnly = true;
            dataGridViewMembresias.RowHeadersWidth = 51;
            dataGridViewMembresias.Size = new Size(664, 292);
            dataGridViewMembresias.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1426, 673);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Sistema de Gestion de Membresias en un Gimnasio";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewClientes).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewMembresias).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnClienteModificar;
        private Button btnClienteAgregar;
        private Button btnClienteBorrar;
        private DataGridView dataGridViewClientes;
        private GroupBox groupBox2;
        private DataGridView dataGridViewMembresias;
        private Button btnMembresiaBorrar;
        private Button btnMembresiaModificar;
        private Button btnMembresiaAgregar;
    }
}
