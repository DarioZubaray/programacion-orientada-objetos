using System;
using System.Windows.Forms;

namespace EjemploServidor
{
    public partial class ServidorForm : Form
    {
        Servidor servidor;

        public ServidorForm()
        {
            InitializeComponent();
        }

        private void Log(string texto)
        {
            // Invoke nos permite ejecutar un delegado en el tread de la UI. 
            // El problema radica en que no es seguro interactuar con los controles
            // de Windows Forms desde múltiples threads. Y en este ejemplo, el 
            // método Log se está llamando desde eventos que se disparan desde
            // threads creados en el objeto Servidor.
            // Ver: https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/how-to-make-thread-safe-calls-to-windows-forms-controls
            Invoke((Action)delegate
            {
                txtLog.AppendText($"{DateTime.Now.ToShortTimeString()} - {texto}");
                txtLog.AppendText($"{Environment.NewLine}");
            });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Inicializo el servidor estableciendo el puerto donde escuchar
            servidor = new Servidor(8050);

            // Me suscribo a los eventos
            servidor.NuevaConexion += Servidor_NuevaConexion;
            servidor.ConexionTerminada += Servidor_ConexionTerminada;
            servidor.DatosRecibidos += Servidor_DatosRecibidos;

            // Comienzo la escucha
            servidor.Escuchar();

            // Grilla de clientes conectados
            InicializarGrillaIps(dataGridView1);
        }

        public void InicializarGrillaIps(DataGridView dgv)
        {
            // Limpieza y configuración
            dgv.AutoGenerateColumns = false; // Importante: evita que se creen columnas duplicadas
            dgv.Columns.Clear();

            // Configuración de la única columna
            DataGridViewTextBoxColumn columna = new DataGridViewTextBoxColumn();
            columna.HeaderText = "Dirección IP";
            columna.Name = "columnaIP";

            // **CLAVE:** El DataPropertyName debe coincidir con el nombre de la propiedad en el objeto anónimo.
            columna.DataPropertyName = "IPAddress";

            columna.ReadOnly = true;

            dgv.Columns.Add(columna);

            // Configuración de selección (para que sea seleccionable)
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToAddRows = false;
        }

        public void EnlazarIpsAGrilla(DataGridView dgv, List<string> listaDeIps)
        {
            // 1. Crear una lista de objetos anónimos con una propiedad llamada "IPAddress"
            var dataParaMostrar = listaDeIps
                                  .Select(ip => new { IPAddress = ip })
                                  .ToList();

            // 2. Asignar la lista mapeada al DataSource
            dgv.DataSource = dataParaMostrar;
        }

        private void Servidor_NuevaConexion(object sender, ServidorEventArgs e)
        {
            //  Muestro quién se conectó
            Log($"Se ha conectado un nuevo cliente desde la IP = {e.EndPoint.Address}, Puerto = {e.EndPoint.Port}");

            EnlazarIpsAGrilla(dataGridView1, servidor?.GetClientesConectados());
        }

        private void Servidor_ConexionTerminada(object sender, ServidorEventArgs e)
        {
            // Muestro con quién se terminó la conexión
            Log($"Se ha desconectado el cliente de la IP = {e.EndPoint.Address}, Puerto = {e.EndPoint.Port}");

            EnlazarIpsAGrilla(dataGridView1, servidor?.GetClientesConectados());
        }

        private void Servidor_DatosRecibidos(object sender, DatosRecibidosEventArgs e)
        {
            // Muestro quién envió el mensaje
            Log($"Mensaje nuevo [IP = {e.EndPoint.Address}, Puerto = {e.EndPoint.Port}]");

            //  Muestro el mensaje recibido
            Log(e.DatosRecibidos);
        }

        private void btnEnviarMensaje_Click(object sender, EventArgs e)
        {
            Log($"Mensaje a todos: {txtMensaje.Text}");
            servidor.EnviarDatos(txtMensaje.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                return;
            }

            if (dataGridView1.SelectedRows.Count > 0)
            {
                var clienteSeleccionado = dataGridView1.SelectedRows[0].Cells[0].Value;

                servidor.EnviarDatosA(txtMensaje.Text, clienteSeleccionado?.ToString());
            }
        }
    }
}
