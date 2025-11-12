namespace GestorEdu
{
    internal class PagoTransferencia : Pago
    {
        // Recargo específico para pagos por transferencia
        public override decimal Recargo => Importe * 0.02m; // 2% de recargo

        // Lógica de procesamiento específica para pagos por transferencia
        public override void ProcesarPago()
        {
            Console.WriteLine("Procesando pago por transferencia.");
        }
    }
}
