namespace ActividadIntegradoraII
{
    public class AccionModificadaEventArgs : EventArgs
    {
        // codigo de accion anterior
        public string CodigoAccionAnterior { get; set; }
        public Accion AccionModificada { get; set; }
        // "Modificacion" o "Eliminacion"
        public string TipoOperacion { get; set; }
    }
}
