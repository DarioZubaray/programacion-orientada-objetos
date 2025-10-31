namespace Actividad_IT12_2
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
            dataGridView1 = new DataGridView();
            comboBoxAtributo = new ComboBox();
            comboBoxCondicion = new ComboBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            textBoxValor = new TextBox();
            buttonBuscar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 89);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(764, 331);
            dataGridView1.TabIndex = 0;
            // 
            // comboBoxAtributo
            // 
            comboBoxAtributo.FormattingEnabled = true;
            comboBoxAtributo.Items.AddRange(new object[] { "Nombre", "Edad", "Ciudad" });
            comboBoxAtributo.Location = new Point(81, 41);
            comboBoxAtributo.Name = "comboBoxAtributo";
            comboBoxAtributo.Size = new Size(150, 28);
            comboBoxAtributo.TabIndex = 1;
            // 
            // comboBoxCondicion
            // 
            comboBoxCondicion.FormattingEnabled = true;
            comboBoxCondicion.Items.AddRange(new object[] { "es", "no es", "es menor", "es mayor" });
            comboBoxCondicion.Location = new Point(238, 41);
            comboBoxCondicion.Name = "comboBoxCondicion";
            comboBoxCondicion.Size = new Size(150, 28);
            comboBoxCondicion.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 44);
            label1.Name = "label1";
            label1.Size = new Size(21, 20);
            label1.TabIndex = 3;
            label1.Text = "Si";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonBuscar);
            groupBox1.Controls.Add(textBoxValor);
            groupBox1.Controls.Add(comboBoxCondicion);
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(comboBoxAtributo);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 426);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Mostrar todas las personas";
            // 
            // textBoxValor
            // 
            textBoxValor.Location = new Point(395, 41);
            textBoxValor.Name = "textBoxValor";
            textBoxValor.Size = new Size(150, 27);
            textBoxValor.TabIndex = 4;
            // 
            // buttonBuscar
            // 
            buttonBuscar.Location = new Point(551, 41);
            buttonBuscar.Name = "buttonBuscar";
            buttonBuscar.Size = new Size(150, 30);
            buttonBuscar.TabIndex = 5;
            buttonBuscar.Text = "Buscar";
            buttonBuscar.UseVisualStyleBackColor = true;
            buttonBuscar.Click += buttonBuscar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private ComboBox comboBoxAtributo;
        private ComboBox comboBoxCondicion;
        private Label label1;
        private GroupBox groupBox1;
        private TextBox textBoxValor;
        private Button buttonBuscar;
    }
}
