namespace GestorEdu
{
    internal class PagoCheque : Pago
    {
        // El recargo específico para para pagos con cheque
        public override decimal Recargo => Importe * 0.05m; // 5% de recargo

        // Lógica de procesamiento específica
        public override void ProcesarPago()
        {
            Console.WriteLine("Procesando pago por cheque. Calculando recargo.");
        }
    }
}