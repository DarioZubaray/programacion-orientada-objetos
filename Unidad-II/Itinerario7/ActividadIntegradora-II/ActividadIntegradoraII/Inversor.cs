namespace ActividadIntegradoraII
{
    internal abstract class Inversor
    {
        #region Atributos
        public int Legajo { get; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public int DNI { get; set; }
        public List<AccionAdquirida> AccionesAdquiridas { get; set; }
        protected virtual float PorcentajeComision => 0.01f;
        public float ComisionesPagadas { get; set; }
        public virtual float TotalGastado { get; set; }
        #endregion

        #region Constructores
        public Inversor(int Legajo)
        {
            this.Legajo = Legajo;
            AccionesAdquiridas = new List<AccionAdquirida>();
            TotalGastado = 0;
        }

        public Inversor(int Legajo, string Apellido, string Nombre, int DNI) : this(Legajo)
        {
            this.Apellido = Apellido;
            this.Nombre = Nombre;
            this.DNI = DNI;
        }
        #endregion

        public string NombreCompleto()
        {
            return $"{Nombre} {Apellido} ({DNI})";
        }

        public virtual void ComprarAccion(Accion accionAComprar, int cantidad)
        {
            AccionAdquirida accionExistente = AccionesAdquiridas.Find(accadq => accadq.Codigo.Equals(accionAComprar.Codigo));
            if (accionExistente != null)
            {
                float monto = accionExistente.CotizacionActual * cantidad;
                ComisionesPagadas = monto * PorcentajeComision;
                TotalGastado += monto + ComisionesPagadas;
                accionExistente.totalAdquirida += cantidad;
            }
            else
            {
                AccionAdquirida accionAdquiridaAComprar = new AccionAdquirida(
                    accionAComprar.Codigo,
                    accionAComprar.Denominacion,
                    accionAComprar.CotizacionActual,
                    accionAComprar.CantidadEmitida
                );
                float monto = accionAdquiridaAComprar.CotizacionActual * cantidad;
                ComisionesPagadas = monto * PorcentajeComision;
                TotalGastado += monto + ComisionesPagadas;
                accionAdquiridaAComprar.totalAdquirida = cantidad;
                AccionesAdquiridas.Add(accionAdquiridaAComprar);
            }
            accionAComprar.Comprar(cantidad);
        }

        public virtual void VenderAccion(Accion accionAVender, int cantidad)
        {
            var accionExistente = AccionesAdquiridas.Find(accadq => accadq.Codigo.Equals(accionAVender.Codigo));
            if (accionExistente != null)
            {
                if (accionExistente.totalAdquirida - cantidad < 0)
                {
                    throw new VentaAccionInvalidaException("No existen la cantidad deseada de acciones a vender.");
                }
                var monto = accionAVender.CotizacionActual * cantidad;
                TotalGastado -= monto;
                accionExistente.totalAdquirida -= cantidad;
                AccionAdquirida accionAdquiridaAVender = new AccionAdquirida(
                    accionAVender.Codigo,
                    accionAVender.Denominacion,
                    accionAVender.CotizacionActual,
                    accionAVender.CantidadEmitida
                );
                AccionesAdquiridas.Remove(accionAdquiridaAVender);
                accionAVender.Vender(cantidad);
            }
            else
            {
                throw new VentaAccionInvalidaException("No existe la accion adquirida a vender");
            }
        }
    }
}
