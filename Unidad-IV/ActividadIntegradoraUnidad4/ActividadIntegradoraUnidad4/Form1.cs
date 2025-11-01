using Microsoft.VisualBasic;

namespace ActividadIntegradoraUnidad4
{
    public partial class Form1 : Form
    {
        private ListaProducto _productos;
        private int _idProducto = 1;
        private string codigoOperador;

        public Form1()
        {
            InitializeComponent();
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _productos = new ListaProducto();
            _idProducto += _productos.Contar();
            dataGridView1.DataSource = _productos.ObtenerTodos();
            var ingresoOperador = Interaction.InputBox("Ingrese número de operador:\n(3 digitos)", "Registro operador", "200").Trim();
            codigoOperador = "OP" + (string.IsNullOrEmpty(ingresoOperador) ? "001" : ingresoOperador);
        }

        private void ActualizarGrilla(DataGridView dataGrid, object pLista)
        {
            dataGrid.DataSource = null;
            dataGrid.DataSource = pLista;
        }

        #region ABM
        // Agregar Producto
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string title = "Registro de producto";
                var numeroLinea = "L" + Interaction.InputBox("Ingrese el número de linea:\n(2 digitos)", title, "").Trim();
                ProductoHelper.ValidarEntrada(ProductoHelper.NUMERO_LINEA, numeroLinea);

                var fechaFabricacion = Interaction.InputBox("Ingrese la fecha de fabricación:\n(formato dd/mm/yyyy)", title, "").Trim();
                ProductoHelper.ValidarEntrada(ProductoHelper.FECHA_FABRICACION, fechaFabricacion);

                var descripcion = Interaction.InputBox("Ingrese descripción:", title, "").Trim();
                ProductoHelper.ValidarEntrada(ProductoHelper.DESCRIPCION, descripcion);

                var precio = Interaction.InputBox("Ingrese precio:", title, "").Trim();
                ProductoHelper.ValidarEntrada(ProductoHelper.PRECIO, precio);

                var stock = Interaction.InputBox("Ingrese stock:", title, "").Trim();
                ProductoHelper.ValidarEntrada(ProductoHelper.STOCK, stock);

                Producto producto = new Producto()
                {
                    Id = ProductoHelper.GenerarId(_idProducto.ToString("D3"), numeroLinea, codigoOperador, fechaFabricacion),
                    Descripcion = descripcion,
                    Precio = decimal.Parse(precio),
                    Stock = int.Parse(stock)
                };

                _productos.Agregar(producto);
                _idProducto++;
                ActualizarGrilla(dataGridView1, _productos.ObtenerTodos());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Borrar Producto
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0) return;

            string? idProducto = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            if (idProducto == null)
            {
                MessageBox.Show($"Ocurrio un error al intentar borrar el producto por id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            var productoARemover = _productos.SingleOrDefault(p => p.Id == idProducto);

            if (productoARemover != null)
            {
                _productos.Borrar(productoARemover);
                ActualizarGrilla(dataGridView1, _productos.ObtenerTodos());
            }
            else
            {
                MessageBox.Show($"Ocurrio un error al intentar borrar el producto con id: {idProducto}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Modificar Producto
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0) return;

            string? idProducto = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            if (idProducto == null)
            {
                MessageBox.Show($"Ocurrio un error al intentar modificar el producto por id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var productoAModificar = _productos.EncontrarPorId(idProducto);

            if (productoAModificar != null)
            {
                try
                {
                    string title = "Registro de producto";
                    var descripcion = Interaction.InputBox("Ingrese descripción:", title, "").Trim();
                    ProductoHelper.ValidarEntrada(ProductoHelper.DESCRIPCION, descripcion);

                    var precio = Interaction.InputBox("Ingrese precio:", title, "").Trim();
                    ProductoHelper.ValidarEntrada(ProductoHelper.PRECIO, precio);

                    var stock = Interaction.InputBox("Ingrese stock:", title, "").Trim();
                    ProductoHelper.ValidarEntrada(ProductoHelper.STOCK, stock);

                    productoAModificar.Actualizar(descripcion, precio, stock);

                    var indiceProducto = _productos.EncontrarIndice(idProducto);
                    _productos.Modificar(productoAModificar, indiceProducto);
                    ActualizarGrilla(dataGridView1, _productos.ObtenerTodos());

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"Ocurrio un error al intentar modificar el producto con id: {idProducto}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Ordenamiento
        private void button4_Click(object sender, EventArgs e)
        {
            _productos.OrdenarIdAscendente();
            ActualizarGrilla(dataGridView1, _productos.ObtenerTodos());
        }
        private void button5_Click(object sender, EventArgs e)
        {
            _productos.OrdenarIdDescendente();
            ActualizarGrilla(dataGridView1, _productos.ObtenerTodos());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            _productos.OrdenarPrecioAscendente();
            ActualizarGrilla(dataGridView1, _productos.ObtenerTodos());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _productos.OrdenarPrecioDescendente();
            ActualizarGrilla(dataGridView1, _productos.ObtenerTodos());
        }
        #endregion

        #region Clonar
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Index < 0)
                return;

            int index = dataGridView1.CurrentRow.Index;
            if (index >= _productos.Contar())
                return;

            if (dataGridView1.SelectedRows.Count == 0)
                return;

            string? idProducto = dataGridView1.SelectedRows[0]?.Cells[0]?.Value?.ToString();
            if (idProducto == null)
            {
                MessageBox.Show($"Ocurrio un error al intentar clonar el producto por id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            label4.Text = idProducto;
            label5.Text = idProducto;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var idProducto = label4.Text;
            var productoAModificar = _productos.EncontrarPorId(idProducto);

            if (productoAModificar != null)
            {
                var productoClonado = productoAModificar.ClonTipado;

                productoClonado.Id = ProductoHelper.ModificarIdClonado(idProducto);
                _productos.Agregar(productoClonado);
                ActualizarGrilla(dataGridView1, _productos.ObtenerTodos());
            }
            else
            {
                MessageBox.Show($"Ocurrio un error al intentar modificar el producto con id: {idProducto}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Mostrar Id partes

        private void button9_Click(object sender, EventArgs e)
        {
            var idProducto = label5.Text;
            var productoAMostrar = _productos.EncontrarPorId(idProducto);

            int indiceNombrePartes = 0;
            string[] nombrePartes = { "código producto", "número de línea", "código operación", "fecha fabricación" };
            if (productoAMostrar != null)
            {
                foreach (string parteId in productoAMostrar)
                {
                    MessageBox.Show($"Parte {nombrePartes[indiceNombrePartes]}: {parteId}", "Mostrando Id partes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    indiceNombrePartes++;
                }
            }
        }
        #endregion
    }
}
