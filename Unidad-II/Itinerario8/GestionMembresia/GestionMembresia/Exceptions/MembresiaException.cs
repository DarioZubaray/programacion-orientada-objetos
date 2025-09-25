namespace GestionMembresia.Exceptions
{
    internal class MembresiaException : Exception
    {
        public MembresiaException(string mensajePersonalizado) : base(mensajePersonalizado) { }
    }
}
