using System;

namespace GuiaEjercicio_IT5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Programa de Gestión de Cuentas Bancarias ===\n");

            // Suscribirse a los eventos estáticos antes de crear instancias
            CuentaBancaria.OnCuentaCreada += (mensaje) =>
                Console.WriteLine($"[EVENTO] {mensaje}");

            CuentaBancaria.OnTransaccionGrande += (descripcion, cantidad) =>
                Console.WriteLine($"[ALERTA] {descripcion} - Cantidad: ${cantidad}");

            Console.WriteLine($"Total de cuentas al inicio: {CuentaBancaria.ObtenerTotalCuentas()}\n");

            // Crear instancias de la clase
            var cuenta1 = new CuentaBancaria("001-2025", 500);
            var cuenta2 = new CuentaBancaria("002-2025", 1000);

            Console.WriteLine($"\nTotal de cuentas después de crear 2: {CuentaBancaria.ObtenerTotalCuentas()}\n");

            // Usar los métodos
            cuenta1.Depositar(1500); // Esto disparará el evento de transacción grande
            cuenta1.ConsultarSaldo();

            Console.WriteLine();

            cuenta2.Retirar(1200); // Esto también disparará el evento
            cuenta2.ConsultarSaldo();

            Console.WriteLine();
            cuenta1.Retirar(3000); // Saldo insuficiente

            Console.WriteLine($"\nTotal final de cuentas: {CuentaBancaria.ObtenerTotalCuentas()}");
        }
    }
}
