namespace GestorEdu.Entities
{
    internal class PagoCheque : Pago
    {
        public const string TIPO = "Cheque";
        // El recargo específico para para pagos con cheque
        public override decimal Recargo => Importe * 0.05m; // 5% de recargo

        // Lógica de procesamiento específica
        public override void ProcesarPago()
        {
            if(ValidarFechaVencida())
            {
                Importe = Recargo;
            }

            if(Importe > 15000m)
            {
                // Desencadenar evento
                MessageBox.Show("El importe ha superado el techo de $15.000,00.-", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}