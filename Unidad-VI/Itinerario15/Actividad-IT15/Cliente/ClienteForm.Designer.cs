namespace EjemploCliente
{
    partial class ClienteForm
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
            label1 = new Label();
            label2 = new Label();
            txtPuerto = new TextBox();
            txtIP = new TextBox();
            btnConectar = new Button();
            txtMensaje = new TextBox();
            btnEnviarMensaje = new Button();
            txtLog = new TextBox();
            btnEnviarMensajeATodos = new Button();
            txtIpPrivate = new TextBox();
            txtPortPrivate = new TextBox();
            label3 = new Label();
            label4 = new Label();
            btnEnviarAIp = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 23);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(24, 20);
            label1.TabIndex = 0;
            label1.Text = "IP:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 63);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(55, 20);
            label2.TabIndex = 1;
            label2.Text = "Puerto:";
            // 
            // txtPuerto
            // 
            txtPuerto.Location = new Point(79, 58);
            txtPuerto.Margin = new Padding(4, 5, 4, 5);
            txtPuerto.Name = "txtPuerto";
            txtPuerto.Size = new Size(132, 27);
            txtPuerto.TabIndex = 2;
            txtPuerto.Text = "8050";
            // 
            // txtIP
            // 
            txtIP.Location = new Point(79, 18);
            txtIP.Margin = new Padding(4, 5, 4, 5);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(132, 27);
            txtIP.TabIndex = 1;
            txtIP.Text = "127.0.0.1";
            // 
            // btnConectar
            // 
            btnConectar.Location = new Point(79, 98);
            btnConectar.Margin = new Padding(4, 5, 4, 5);
            btnConectar.Name = "btnConectar";
            btnConectar.Size = new Size(100, 35);
            btnConectar.TabIndex = 3;
            btnConectar.Text = "Conectar";
            btnConectar.UseVisualStyleBackColor = true;
            btnConectar.Click += btnConectar_Click;
            // 
            // txtMensaje
            // 
            txtMensaje.Enabled = false;
            txtMensaje.Location = new Point(299, 18);
            txtMensaje.Margin = new Padding(4, 5, 4, 5);
            txtMensaje.Name = "txtMensaje";
            txtMensaje.Size = new Size(308, 27);
            txtMensaje.TabIndex = 4;
            // 
            // btnEnviarMensaje
            // 
            btnEnviarMensaje.Enabled = false;
            btnEnviarMensaje.Location = new Point(299, 54);
            btnEnviarMensaje.Margin = new Padding(4, 5, 4, 5);
            btnEnviarMensaje.Name = "btnEnviarMensaje";
            btnEnviarMensaje.Size = new Size(100, 35);
            btnEnviarMensaje.TabIndex = 5;
            btnEnviarMensaje.Text = "Enviar";
            btnEnviarMensaje.UseVisualStyleBackColor = true;
            btnEnviarMensaje.Click += btnEnviarMensaje_Click;
            // 
            // txtLog
            // 
            txtLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtLog.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLog.Location = new Point(16, 171);
            txtLog.Margin = new Padding(4, 5, 4, 5);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ScrollBars = ScrollBars.Both;
            txtLog.Size = new Size(632, 547);
            txtLog.TabIndex = 7;
            txtLog.WordWrap = false;
            // 
            // btnEnviarMensajeATodos
            // 
            btnEnviarMensajeATodos.Enabled = false;
            btnEnviarMensajeATodos.Location = new Point(486, 54);
            btnEnviarMensajeATodos.Margin = new Padding(4, 5, 4, 5);
            btnEnviarMensajeATodos.Name = "btnEnviarMensajeATodos";
            btnEnviarMensajeATodos.Size = new Size(120, 35);
            btnEnviarMensajeATodos.TabIndex = 8;
            btnEnviarMensajeATodos.Text = "Enviar a Todos";
            btnEnviarMensajeATodos.UseVisualStyleBackColor = true;
            btnEnviarMensajeATodos.Click += btnEnviarMensajeATodos_Click;
            // 
            // txtIpPrivate
            // 
            txtIpPrivate.Enabled = false;
            txtIpPrivate.Location = new Point(362, 99);
            txtIpPrivate.Margin = new Padding(4, 5, 4, 5);
            txtIpPrivate.Name = "txtIpPrivate";
            txtIpPrivate.Size = new Size(101, 27);
            txtIpPrivate.TabIndex = 9;
            // 
            // txtPortPrivate
            // 
            txtPortPrivate.Enabled = false;
            txtPortPrivate.Location = new Point(362, 134);
            txtPortPrivate.Margin = new Padding(4, 5, 4, 5);
            txtPortPrivate.Name = "txtPortPrivate";
            txtPortPrivate.Size = new Size(101, 27);
            txtPortPrivate.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(299, 101);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(24, 20);
            label3.TabIndex = 11;
            label3.Text = "IP:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(299, 138);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(55, 20);
            label4.TabIndex = 12;
            label4.Text = "Puerto:";
            // 
            // btnEnviarAIp
            // 
            btnEnviarAIp.Enabled = false;
            btnEnviarAIp.Location = new Point(471, 98);
            btnEnviarAIp.Margin = new Padding(4, 5, 4, 5);
            btnEnviarAIp.Name = "btnEnviarAIp";
            btnEnviarAIp.Size = new Size(135, 60);
            btnEnviarAIp.TabIndex = 13;
            btnEnviarAIp.Text = "Enviar a IP";
            btnEnviarAIp.UseVisualStyleBackColor = true;
            btnEnviarAIp.Click += btnEnviarAIp_Click;
            // 
            // ClienteForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(665, 738);
            Controls.Add(btnEnviarAIp);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtPortPrivate);
            Controls.Add(txtIpPrivate);
            Controls.Add(btnEnviarMensajeATodos);
            Controls.Add(txtLog);
            Controls.Add(btnEnviarMensaje);
            Controls.Add(txtMensaje);
            Controls.Add(btnConectar);
            Controls.Add(txtIP);
            Controls.Add(txtPuerto);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ClienteForm";
            Text = "Cliente";
            Load += ClienteForm_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPuerto;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.Button btnEnviarMensaje;
        private System.Windows.Forms.TextBox txtLog;
        private Button btnEnviarMensajeATodos;
        private TextBox txtIpPrivate;
        private TextBox txtPortPrivate;
        private Label label3;
        private Label label4;
        private Button btnEnviarAIp;
    }
}

