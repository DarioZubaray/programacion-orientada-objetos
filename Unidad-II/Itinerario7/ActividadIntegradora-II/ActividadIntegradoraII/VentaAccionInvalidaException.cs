public class VentaAccionInvalidaException : Exception
{
    public VentaAccionInvalidaException()
        : base("No es posible vender la cantidad solicitada de acciones.") { }

    public VentaAccionInvalidaException(string mensajePersonalizado)
        : base(mensajePersonalizado) { }

    public VentaAccionInvalidaException(string mensaje, Exception inner)
        : base(mensaje, inner) { }
}
