namespace GestorEdu.Entities
{
    internal class PagoTransferencia : Pago
    {
        // Tipo de pago
        public static string TIPO = "Transferencia";
        // Recargo específico para pagos por transferencia
        public override decimal Recargo => Importe * 0.02m; // 2% de recargo

    }
}
