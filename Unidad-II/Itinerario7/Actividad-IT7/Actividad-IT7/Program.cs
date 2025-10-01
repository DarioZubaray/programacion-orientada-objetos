namespace Actividad_IT7
{
    // Desarrollar un programa donde se observe claramente el uso de los miembros de base en un entorno de herencia.
    // Enfatice las particularidades al usarlo en los constructores y finalizadores.
    // Demuestre en el mismo programa el uso de this.
    // Establezca las diferencias y en qué caso se justifica utilizar cada uno.
    internal class Program
    {
        private const int TIEMPO_ESPERA = 1000;
        private static void Main(string[] args)
        {
            Console.WriteLine("═══ 1. CREANDO AUTOS [4 parametros] ═══\n");
 
            Console.WriteLine("new Auto(\"Toyota\", \"Corolla\", 2011, 4)");
            Console.WriteLine("\nOrden de llamada de constructores:");
            Auto auto1 = new Auto("Toyota", "Corolla", 2011, 4);
            Console.WriteLine("\n\t--- Informacion del auto 1 ---");
            auto1.MostrarInformacion();

            Console.WriteLine("\n\nnew Auto(\"Citroen\", \"C3 picasso\", 2018, 5)");
            Console.WriteLine("\nOrden de llamada de constructores:");
            Auto auto2 = new Auto("Citroen", "C3 picasso", 2018, 5);
            Console.WriteLine("\n\t--- Informacion del auto 2 ---");
            auto2.MostrarInformacion();
            Thread.Sleep(TIEMPO_ESPERA);

            Console.WriteLine("\n\n═══ 2. CREANDO MOTO  [4 parametros] ═══\n");
            Console.WriteLine("new Moto(\"Suzuki\", \"Gixxer\", 2018, 150)");
            Console.WriteLine("\nOrden de llamada de constructores:");
            Moto moto1 = new Moto("Suzuki", "Gixxer", 2018, 150);
            Console.WriteLine("\n\t--- Informacion de la moto ---");
            moto1.MostrarInformacion();
            Thread.Sleep(TIEMPO_ESPERA);

            Console.WriteLine("\n\n═══ 3. ENCADENAMIENTO CON 'this' ═══\n");
            Console.WriteLine("Antes de actualizar:");
            auto1.MostrarInformacion();
            Console.WriteLine("\nauto1.ActualizarNumeroPuertas(5).ActualizarTipoCombustible(\"Diesel\")");
            Console.WriteLine("\t.ActualizarMarca(\"Peugeot\").ActualizarModelo(\"208\").ActualizarAnio(2020)\n");
            auto1.ActualizarNumeroPuertas(5).ActualizarTipoCombustible("Diesel")          // Aca estos metodos devuelven tipo Auto
                .ActualizarMarca("Peugeot").ActualizarModelo("208").ActualizarAnio(2020); // Aca devuelven tipo Vehiculo
            Console.WriteLine("Despues de actualizar:");
            auto1.MostrarInformacion();
            Thread.Sleep(TIEMPO_ESPERA);

            Console.WriteLine("\n\n═══ 4. COMPARANDO TIPOS ═══\n");
            Console.WriteLine($"Total de vehiculos: {Auto.TotalVehiculos}");
            Console.WriteLine($"Tipo de auto1: {auto1.ObtenerTipo()}");
            Console.WriteLine($"Tipo de auto2: {auto2.ObtenerTipo()}");
            Console.WriteLine($"Tipo de moto1: {moto1.ObtenerTipo()}");
            Thread.Sleep(TIEMPO_ESPERA);

            Console.WriteLine("\n\n═══ 5. FINALIZADORES ═══");
            Console.WriteLine("Al salir del programa, se observa el orden de llamada de finalizadores.");
            Console.WriteLine("(El orden es inverso: derivada -> base)\n");

            GC.Collect();                  // Fuerza la recolección
            GC.WaitForPendingFinalizers(); // Espera que se ejecuten los finalizadores

            Console.WriteLine("Presionar cualquier tecla para finalizar y ver los finalizadores...");
            Console.ReadKey();
            Console.WriteLine("Los finalizadores se invocan cuando el recolector de basura decide liberar objetos, lo cual no ocurre de forma determinista ni inmediata.");
        }
    }
}