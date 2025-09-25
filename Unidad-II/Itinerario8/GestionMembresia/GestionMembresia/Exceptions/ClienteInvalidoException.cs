namespace GestionMembresia.Exceptions
{
    internal class ClienteInvalidoException : Exception
    {
        public ClienteInvalidoException(string mensajePersonalizado) : base(mensajePersonalizado) { }
}
}
