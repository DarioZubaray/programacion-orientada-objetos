using System;

namespace GuiaEjercicio_IT5
{
    // Clase principal del programa
    public class CuentaBancaria
    {
        #region Campos (Fields)
        
        // Campo privado - Encapsulación: Protege el acceso directo al saldo
        private decimal _saldo;
        
        // Campo público - Accesibilidad: Puede ser accedido desde cualquier parte
        public string NumeroCuenta;
        
        // Campo estático - Compartido por todas las instancias de la clase
        private static int _contadorCuentas = 0;
        
        #endregion

        #region Constructor
        
        // Constructor - Inicialización: Permite establecer el estado inicial del objeto
        public CuentaBancaria(string numeroCuenta, decimal saldoInicial = 0)
        {
            NumeroCuenta = numeroCuenta;
            _saldo = saldoInicial;
            _contadorCuentas++; // Incrementa el contador estático
            
            Console.WriteLine($"Cuenta {numeroCuenta} creada con saldo inicial: ${saldoInicial}");
            
            // Disparar evento cuando se crea una cuenta
            OnCuentaCreada?.Invoke($"Nueva cuenta creada: {numeroCuenta}");
        }
        
        #endregion

        #region Eventos Estáticos
        
        // Evento estático 1 - Notificación global: Todos pueden suscribirse sin necesidad de instancia
        public static event Action<string> OnCuentaCreada;
        
        // Evento estático 2 - Notificación global: Alerta de transacciones grandes
        public static event Action<string, decimal> OnTransaccionGrande;
        
        #endregion

        #region Métodos
        
        // Método 1 - Funcionalidad: Permite depositar dinero
        public void Depositar(decimal cantidad)
        {
            if (cantidad <= 0)
            {
                Console.WriteLine("La cantidad a depositar debe ser positiva.");
                return;
            }
            
            _saldo += cantidad;
            Console.WriteLine($"Depósito de ${cantidad} realizado. Saldo actual: ${_saldo}");
            
            // Disparar evento si es una transacción grande
            if (cantidad > 1000)
            {
                OnTransaccionGrande?.Invoke($"Depósito grande en cuenta {NumeroCuenta}", cantidad);
            }
        }
        
        // Método 2 - Funcionalidad: Permite retirar dinero con validación
        public bool Retirar(decimal cantidad)
        {
            if (cantidad <= 0)
            {
                Console.WriteLine("La cantidad a retirar debe ser positiva.");
                return false;
            }
            
            if (cantidad > _saldo)
            {
                Console.WriteLine("Saldo insuficiente para realizar el retiro.");
                return false;
            }
            
            _saldo -= cantidad;
            Console.WriteLine($"Retiro de ${cantidad} realizado. Saldo actual: ${_saldo}");
            
            // Disparar evento si es una transacción grande
            if (cantidad > 1000)
            {
                OnTransaccionGrande?.Invoke($"Retiro grande en cuenta {NumeroCuenta}", cantidad);
            }
            
            return true;
        }
        
        // Método 3 - Acceso controlado: Permite consultar el saldo (getter personalizado)
        public decimal ConsultarSaldo()
        {
            Console.WriteLine($"Saldo actual de la cuenta {NumeroCuenta}: ${_saldo}");
            return _saldo;
        }
        
        // Método estático - Utilidad de clase: No requiere instancia para ser llamado
        public static int ObtenerTotalCuentas()
        {
            return _contadorCuentas;
        }
        
        #endregion
    }
}
