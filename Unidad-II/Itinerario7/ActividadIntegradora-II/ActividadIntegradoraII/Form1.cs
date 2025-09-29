using Microsoft.VisualBasic;
using System;

namespace ActividadIntegradoraII
{
    public partial class Form1 : Form
    {
        List<Inversor> _inversores;
        List<Accion> _acciones;

        private int _legajoInversionista = 1;

        public event EventHandler<AccionModificadaEventArgs> AccionModificada;

        public Form1()
        {
            InitializeComponent();

            //_inversores = FormularioHelper.getInversoresListMock();
            _inversores = new List<Inversor>();
            _legajoInversionista += _inversores.Count;

            //_acciones = FormularioHelper.getAccionesListMock();
            _acciones = new List<Accion>();
            /*
            var accionista1 = _inversores[0];
            accionista1.ComprarAccion(_acciones[0], 30);
            accionista1.ComprarAccion(_acciones[2], 10);

            var accionista3 = _inversores[2];
            accionista3.ComprarAccion(_acciones[0], 30);
            */
            RefreshUI();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridViewInversores.MultiSelect = false;
            dataGridViewInversores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewInversores.AllowUserToOrderColumns = true;

            dataGridViewAcciones.MultiSelect = false;
            dataGridViewAcciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridViewCompraVenta.MultiSelect = false;
            dataGridViewCompraVenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void RefreshUI()
        {
            dataGridViewInversores.DataSource = null;
            dataGridViewAcciones.DataSource = null;
            dataGridViewCompraVenta.DataSource = null;

            var inversoresOrdenable = new SortableBindingList<Inversor>(_inversores.ToList());
            dataGridViewInversores.DataSource = inversoresOrdenable;

            dataGridViewInversores.Columns["ComisionesPagadas"].Visible = false;
            dataGridViewInversores.Columns["TotalGastado"].Visible = false;

            var accionesOrdenable = new SortableBindingList<Accion>(_acciones.ToList());
            dataGridViewAcciones.DataSource = accionesOrdenable;

            if (_inversores.Count > 0)
            {
                var compraVenta = _inversores[0].AccionesAdquiridas.Select(a => new
                {
                    a.Codigo,
                    a.Denominacion,
                    a.CotizacionActual,
                    a.CantidadEmitida,
                    a.totalAdquirida,
                    ValorInversion = a.getValorInversion()
                }).ToList();

                dataGridViewCompraVenta.DataSource = compraVenta;
            }
        }

        protected virtual void OnAccionModificada(string codigoAccionAnterior, Accion accion, string tipoOperacion)
        {
            AccionModificada?.Invoke(this, new AccionModificadaEventArgs
            {
                CodigoAccionAnterior = codigoAccionAnterior,
                AccionModificada = accion,
                TipoOperacion = tipoOperacion
            });
        }

        #region Click Inversores
        private void btnInversorAgregar_Click(object sender, EventArgs e)
        {
            string title = "Registro de inversor";
            string nombre = Interaction.InputBox("Ingrese nombre:", title, "");
            string apellido = Interaction.InputBox("Ingrese apellido:", title, "");
            string DNI = Interaction.InputBox("Ingrese DNI:", title, "");

            if (!FormularioHelper.ValidarInversor(nombre, apellido, DNI))
            {
                MessageBox.Show("Los datos ingresados no son válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var nuevoInversionista = new InversorComun(_legajoInversionista++, apellido, nombre, int.Parse(DNI));

            _inversores.Add(nuevoInversionista);
            RefreshUI();
        }

        private void btnInversorModificar_Click(object sender, EventArgs e)
        {
            if (dataGridViewInversores.Rows.Count == 0) return;

            int legajoAModificar = Convert.ToInt32(dataGridViewInversores.SelectedRows[0].Cells[0].Value);
            Inversor? inversorAModificar = _inversores.Find(i => i.Legajo.Equals(legajoAModificar));

            if (inversorAModificar == null)
            {
                MessageBox.Show("Ocurrió un error al modificar el inversor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string title = "Modificación de inversor";
            string nuevoNombre = Interaction.InputBox("Ingrese nombre:", title, inversorAModificar.Nombre);
            string nuevoApellido = Interaction.InputBox("Ingrese apellido:", title, inversorAModificar.Apellido);
            string nuevoDNI = Interaction.InputBox("Ingrese DNI:", title, inversorAModificar.DNI.ToString());

            if (!FormularioHelper.ValidarInversor(nuevoNombre, nuevoApellido, nuevoDNI))
            {
                MessageBox.Show("Los datos ingresados no son válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            inversorAModificar.Nombre = nuevoNombre;
            inversorAModificar.Apellido = nuevoApellido;
            inversorAModificar.DNI = int.Parse(nuevoDNI);
            RefreshUI();
        }

        private void btnInversorBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridViewInversores.Rows.Count == 0) return;

            int legajoABorrar = Convert.ToInt32(dataGridViewInversores.SelectedRows[0].Cells[0].Value);
            Inversor? inversorABorrar = _inversores.Find(inversor => inversor.Legajo.Equals(legajoABorrar));

            if (inversorABorrar == null)
            {
                MessageBox.Show("Ocurrio un error al borrar el inversor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (inversorABorrar.AccionesAdquiridas.Count > 0)
            {
                var resultInvesorConAcciones = MessageBox.Show($"Seguro que quiere borrar a {inversorABorrar.NombreCompleto()}", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultInvesorConAcciones.Equals(DialogResult.OK))
                {
                    foreach (var accionAdquirida in inversorABorrar.AccionesAdquiridas)
                    {
                        accionAdquirida.Vender(accionAdquirida.totalAdquirida);
                    }
                }
            }

            var result = MessageBox.Show($"Seguro que quiere borrar a {inversorABorrar.NombreCompleto()}", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result.Equals(DialogResult.Yes))
            {
                _inversores.Remove(inversorABorrar);
                RefreshUI();
            }
        }

        private void dataGridViewInversores_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewInversores.CurrentRow != null)
            {
                Inversor accionistaSeleccionado = dataGridViewInversores.CurrentRow.DataBoundItem as Inversor;
                if (accionistaSeleccionado != null && accionistaSeleccionado.AccionesAdquiridas.Count > 0)
                {
                    float totalInversion = accionistaSeleccionado.AccionesAdquiridas.Sum(accion => accion.totalAdquirida * accion.CotizacionActual);
                    txtTotalInvertido.Text = totalInversion.ToString();

                    var compraVenta = accionistaSeleccionado.AccionesAdquiridas.Select(a => new
                    {
                        a.Codigo,
                        a.Denominacion,
                        a.CotizacionActual,
                        a.CantidadEmitida,
                        a.totalAdquirida,
                        ValorInversion = a.getValorInversion()
                    }).ToList();

                    dataGridViewCompraVenta.DataSource = compraVenta;
                }
                else
                {
                    txtTotalInvertido.Text = "0";
                    dataGridViewCompraVenta.DataSource = null;
                }
            }
        }
        #endregion

        #region Click Acciones
        private void btnAccionesAgregar_Click(object sender, EventArgs e)
        {
            string title = "Registro de acción";
            string denominacion = Interaction.InputBox("Ingrese nombre de la empresa:", title, "");
            string codigo = Interaction.InputBox("Ingrese código:\n(4 caracteres)", title, "");
            string cotizacionActual = Interaction.InputBox("Ingrese la cotización actual $:", title, "");
            string cantidadEmitida = Interaction.InputBox("Ingrese cantidad emitida:", title, "");

            if (!FormularioHelper.ValidarAccion(denominacion, codigo, cotizacionActual, cantidadEmitida))
            {
                MessageBox.Show("Los datos ingresados no son válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var nuevaAccion = new Accion(FormularioHelper.GenerarIdentificador(codigo), denominacion, float.Parse(cotizacionActual), int.Parse(cantidadEmitida));
            _acciones.Add(nuevaAccion);
            RefreshUI();

        }

        private void btnAccionesModificar_Click(object sender, EventArgs e)
        {
            if (dataGridViewAcciones.Rows.Count == 0) return;

            string? accionCodigoAModificar = dataGridViewAcciones.SelectedRows[0].Cells[0]?.Value?.ToString();
            Accion? accionAModificar = _acciones.Find(accion => accion.Codigo.Equals(accionCodigoAModificar));

            if (accionAModificar == null)
            {
                MessageBox.Show("Ocurrió un error al modificar la acción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string title = "Modificación de acción";
            string denominacion = Interaction.InputBox("Ingrese nombre de la empresa:", title, accionAModificar.Denominacion);
            string codigo = Interaction.InputBox("Ingrese código:\n(4 caracteres)", title, accionAModificar.Codigo.Substring(0, 3));
            string cotizacionActual = Interaction.InputBox("Ingrese la cotización actual $:", title, accionAModificar.CotizacionActual.ToString());
            string cantidadEmitida = Interaction.InputBox("Ingrese cantidad emitida:", title, accionAModificar.CantidadEmitida.ToString());

            if (!FormularioHelper.ValidarAccion(denominacion, codigo, cotizacionActual, cantidadEmitida))
            {
                MessageBox.Show("Los datos ingresados no son válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            accionAModificar.Denominacion = denominacion;
            accionAModificar.Codigo = FormularioHelper.GenerarIdentificador(codigo);
            accionAModificar.CotizacionActual = float.Parse(cotizacionActual);
            accionAModificar.CantidadEmitida = int.Parse(cantidadEmitida);

            OnAccionModificada(accionCodigoAModificar, accionAModificar, "Modificacion");
            RefreshUI();
        }

        private void btnAccionesBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridViewAcciones.Rows.Count == 0) return;

            string? accionCodigoABorrar = dataGridViewAcciones.SelectedRows[0].Cells[0]?.Value?.ToString();
            Accion? accionABorrar = _acciones.Find(accion => accion.Codigo.Equals(accionCodigoABorrar));

            if (accionABorrar == null)
            {
                MessageBox.Show("Ocurrio un error al borrar la acción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show($"Seguro que quiere borrar a {accionABorrar.Denominacion}", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result.Equals(DialogResult.Yes))
            {
                OnAccionModificada(accionCodigoABorrar, accionABorrar, "Eliminacion");
                _acciones.Remove(accionABorrar);

                 _inversores.ForEach(inversionista => {
                     var accionSubscripta = inversionista.AccionesAdquiridas.Find(accion => accion.Codigo.Equals(accionCodigoABorrar));
                     if(accionSubscripta != null)
                        AccionModificada -= inversionista.GestorAcciones_AccionModificada;
                });
                
                RefreshUI();
            }
        }

        private void dataGridViewAcciones_SelectionChanged(object sender, EventArgs e)
        {
            lblCompra.Text = String.Empty;
            if (dataGridViewAcciones.CurrentRow == null)
            {
                lblCompra.Text = "";
                return;
            }

            Accion seleccionado = dataGridViewAcciones.CurrentRow.DataBoundItem as Accion;
            if (seleccionado != null)
            {
                ICodigoAccionParser parser = new CodigoAccionParser();
                foreach (var parte in parser.ObtenerPartes(seleccionado.Codigo))
                {
                    lblCompra.Text += parte;
                }
            }
        }
        #endregion

        #region Compra Venta
        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (dataGridViewInversores.Rows.Count == 0 || dataGridViewAcciones.Rows.Count == 0) return;

            try
            {
                int cantidad = int.Parse(txtCantidad.Text);
                if (cantidad <= 0)
                {
                    txtCantidad.Text = "1";
                    MessageBox.Show("La cantidad a comprar no puede ser cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string? accionCodigoAComprar = dataGridViewAcciones.SelectedRows[0].Cells[0]?.Value?.ToString();
                var accion = _acciones.Find(ac => ac.Codigo.Equals(accionCodigoAComprar));

                Inversor inversorSeleccionado = dataGridViewInversores.CurrentRow.DataBoundItem as Inversor;
                if (inversorSeleccionado == null)
                    throw new Exception("Ha ocurrido un error, intente mas tarde.");

                inversorSeleccionado.ComprarAccion(accion, cantidad);
                if(!inversorSeleccionado.AccionSubscripta(accionCodigoAComprar))
                    AccionModificada += inversorSeleccionado.GestorAcciones_AccionModificada;

                if (inversorSeleccionado.TotalGastado >= 20000 && inversorSeleccionado is InversorComun)
                {
                    var nuevoPremium = new InversorPremium(inversorSeleccionado.Legajo);
                    nuevoPremium.Apellido = inversorSeleccionado.Apellido;
                    nuevoPremium.Nombre = inversorSeleccionado.Nombre;
                    nuevoPremium.DNI = inversorSeleccionado.DNI;
                    nuevoPremium.AccionesAdquiridas = inversorSeleccionado.AccionesAdquiridas
                                                                        .Select(ac => ac.CloneTipado())
                                                                        .ToList();
                    nuevoPremium.TotalGastadoInversorComun = inversorSeleccionado.TotalGastado;
                    nuevoPremium.TotalGastado = inversorSeleccionado.TotalGastado;
                    AccionModificada -= inversorSeleccionado.GestorAcciones_AccionModificada;
                    AccionModificada += nuevoPremium.GestorAcciones_AccionModificada;

                    // Reemplazar en la lista
                    _inversores.Remove(inversorSeleccionado);
                    _inversores.Add(nuevoPremium);
                }

                RefreshUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            if (dataGridViewInversores.Rows.Count == 0 || dataGridViewCompraVenta.Rows.Count == 0) return;

            try
            {
                int cantidad = int.Parse(txtCantidad.Text);
                if (cantidad <= 0)
                {
                    txtCantidad.Text = "1";
                    MessageBox.Show("La cantidad a vender no puede ser cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string? accionCodigoAComprar = dataGridViewCompraVenta.SelectedRows[0].Cells[0]?.Value?.ToString();
                var accionAVender = _acciones.Find(ac => ac.Codigo.Equals(accionCodigoAComprar));
                Inversor inversorSeleccionado = dataGridViewInversores.CurrentRow.DataBoundItem as Inversor;
                if (inversorSeleccionado == null)
                    throw new Exception("Ha ocurrido un error, intente mas tarde.");

                inversorSeleccionado.VenderAccion(accionAVender, cantidad);
                RefreshUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridViewCompraVenta_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewCompraVenta.SelectedRows.Count > 0)
            {
                var valorCelda = dataGridViewCompraVenta.SelectedRows[0].Cells[0].Value;
                if (valorCelda != null)
                {
                    lblVenta.Text = $"({valorCelda.ToString()})";
                }
            }
            else
            {
                lblVenta.Text = string.Empty;
            }
        }
        #endregion

        private void btnMas_Click(object sender, EventArgs e)
        {
            int cantidad = int.Parse(txtCantidad.Text);
            txtCantidad.Text = (cantidad + 1).ToString();
        }

        private void btnMenos_Click(object sender, EventArgs e)
        {
            int cantidad = int.Parse(txtCantidad.Text);
            if (cantidad == 0) return;

            txtCantidad.Text = (cantidad - 1).ToString();
        }

        private void btnVerComisiones_Click(object sender, EventArgs e)
        {
            /*
             a) Label1: El total recaudado por operaciones de los clientes comunes.
             b) Label2: El total recaudado en concepto de comisiones por operaciones de los clientes premium por los ingresos correspondientes hasta 20.000.
             c) Label3: El total recaudado en concepto de comisiones por operaciones de los clientes premium por los ingresos correspondientes que superan los 20.000.
             d) Labal 4: el total general percibido en concepto de comisiones.
             */
            var totalRecaudadoClienteComunes = _inversores.Where(inv => inv is InversorComun).Sum(inv => inv.TotalGastado);
            var totalRecaudadoComisionesOperacion = _inversores.OfType<InversorPremium>().Sum(inv => inv.TotalGastadoInversorComun);
            var totalRecaudadoClientePremium = _inversores.Where(inv => inv is InversorPremium).Sum(inv => inv.TotalGastado);
            var totalGeneralComisiones = _inversores.Sum(inv => inv.ComisionesPagadas);
            var mensaje = $"Total por operaciones de los clientes comunes: ${totalRecaudadoClienteComunes}{Environment.NewLine}" +
                          $"Total de comisiones de los clientes premium por ingresos hasta 20.000: ${totalRecaudadoComisionesOperacion}{Environment.NewLine}" +
                          $"Total de comisiones por operaciones de premiums por ingresos que superan los 20.000: ${totalRecaudadoClientePremium}{Environment.NewLine}" + 
                          $"Total general percibido en concepto de comisiones: ${totalGeneralComisiones}";
            MessageBox.Show(mensaje, "Comisiones", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
