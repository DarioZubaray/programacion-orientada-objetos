namespace GestorEdu.Entities
{
    internal class PagoCheque : Pago
    {
        // Tipo de pago
        public static string TIPO = "Cheque";
        // El recargo específico para para pagos con cheque
        public override decimal Recargo => Importe * 0.05m; // 5% de recargo
    }
}