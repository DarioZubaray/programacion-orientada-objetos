namespace EjemploServidor
{
    partial class ServidorForm
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
            btnEnviarMensaje = new Button();
            txtMensaje = new TextBox();
            txtLog = new TextBox();
            dataGridView1 = new DataGridView();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnEnviarMensaje
            // 
            btnEnviarMensaje.Location = new Point(545, 18);
            btnEnviarMensaje.Margin = new Padding(4, 5, 4, 5);
            btnEnviarMensaje.Name = "btnEnviarMensaje";
            btnEnviarMensaje.Size = new Size(169, 75);
            btnEnviarMensaje.TabIndex = 3;
            btnEnviarMensaje.Text = "Enviar mensaje a todos los clientes";
            btnEnviarMensaje.UseVisualStyleBackColor = true;
            btnEnviarMensaje.Click += btnEnviarMensaje_Click;
            // 
            // txtMensaje
            // 
            txtMensaje.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMensaje.Location = new Point(16, 18);
            txtMensaje.Margin = new Padding(4, 5, 4, 5);
            txtMensaje.Name = "txtMensaje";
            txtMensaje.Size = new Size(520, 24);
            txtMensaje.TabIndex = 2;
            // 
            // txtLog
            // 
            txtLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtLog.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLog.Location = new Point(16, 103);
            txtLog.Margin = new Padding(4, 5, 4, 5);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ScrollBars = ScrollBars.Both;
            txtLog.Size = new Size(698, 638);
            txtLog.TabIndex = 4;
            txtLog.WordWrap = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(721, 103);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(222, 638);
            dataGridView1.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(721, 18);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(222, 75);
            button1.TabIndex = 6;
            button1.Text = "Enviar mensaje a el cliente seleccionado";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ServidorForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(955, 762);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(txtLog);
            Controls.Add(btnEnviarMensaje);
            Controls.Add(txtMensaje);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ServidorForm";
            Text = "Servidor";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnviarMensaje;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.TextBox txtLog;
        private DataGridView dataGridView1;
        private Button button1;
    }
}

