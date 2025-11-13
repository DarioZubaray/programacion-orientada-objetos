namespace GestorEdu.Exceptions
{
    internal class PagoException : Exception
    {
        public PagoException(string mensajePersonalizado) : base(mensajePersonalizado) { }
}
}
