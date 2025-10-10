namespace Actividad_IT10_2
{
    internal class EdadInvalidaException : Exception
    {
        public EdadInvalidaException()
            : base("La edad ingresada no es válida.") { }

        public EdadInvalidaException(string mensaje)
            : base(mensaje) { }

        public EdadInvalidaException(string mensaje, Exception inner)
            : base(mensaje, inner) { }
    }

}
