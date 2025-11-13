namespace GestorEdu.Entities
{
    internal class PagoTransferencia : Pago
    {
        public const string TIPO = "Transferencia";
        // Recargo específico para pagos por transferencia
        public override decimal Recargo => Importe * 1.02m; // 2% de recargo

        // Lógica de procesamiento específica para pagos por transferencia
        public override void ProcesarPago()
        {
            FechaPago = DateTime.Now;
            if (ValidarFechaVencida())
            {
                Importe = Recargo;
            }

            if (Importe > 15000m)
            {
                // Desencadenar evento de aviso
                MessageBox.Show("El importe ha superado el techo de $15.000,00.-", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
