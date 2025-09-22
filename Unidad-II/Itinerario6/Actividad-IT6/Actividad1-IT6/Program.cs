using Actividad1_IT6;

Console.WriteLine("--- CREACIÓN DE OBJETOS (Constructores) ---");
Thread.Sleep(1000);

Console.WriteLine("\nCreando Vehiculo con constructor por defecto:");
var vehiculo1 = new Vehiculo();
Thread.Sleep(1000);

Console.WriteLine("\nCreando Vehiculo con constructor parametrizado:");
var vehiculo2 = new Vehiculo("Toyota", "Corolla", 2023);
Thread.Sleep(1000);

Console.WriteLine("\nCreando Vehiculo con encadenamiento 'this':");
var vehiculo3 = new Vehiculo("Honda", "Civic");
Thread.Sleep(1000);

Console.WriteLine("\nCreando Automovil (hereda de Vehiculo):");
var auto1 = new Automovil("Ford", "Focus", 2024, 4, "Manual");
Thread.Sleep(1000);

Console.WriteLine("\nCreando Automovil con encadenamiento 'this':");
var auto2 = new Automovil("Chevrolet", "Cruze", 4);
Thread.Sleep(1000);

Console.WriteLine("\nCreando AutomovilElectrico (herencia múltiple):");
var autoElectrico = new AutomovilElectrico("Tesla", "Model 3", 2024, 500, true);
Thread.Sleep(1000);

Console.WriteLine($"\nTotal de vehículos creados: {Vehiculo.ObtenerContadorVehiculos()}");
Thread.Sleep(1000);

Console.WriteLine("\n\n--- USO DE MÉTODOS (base y this) ---");
Thread.Sleep(1000);

Console.WriteLine("\nMostrarInformacion() - Uso de 'base' en métodos:");
vehiculo2.MostrarInformacion();
Console.WriteLine();
Thread.Sleep(1000);

auto1.MostrarInformacion();
Thread.Sleep(1000);

Console.WriteLine();
autoElectrico.MostrarInformacion();
Thread.Sleep(1000);

Console.WriteLine("\nMétodos protegidos con 'base':");
auto1.EncenderAutomovil();
autoElectrico.EncenderAutomovil();
Thread.Sleep(1000);

Console.WriteLine("\nUso de 'this' para devolver la instancia (method chaining):");
auto1.ActualizarAño(2025).ActualizarAño(2026);
Thread.Sleep(1000);

Console.WriteLine("\nUso de 'this' como parámetro de comparación:");
auto1.CompararCon(auto2);
auto1.CompararCon(auto1); // Se compara consigo mismo
Thread.Sleep(1000);

Console.WriteLine("\nMethod chaining con 'this' en clase derivada:");
autoElectrico.CargarBateria(85).ActualizarAño(2025);
Thread.Sleep(1000);

// Forzar recolección de basura para ver finalizadores
vehiculo1 = null;
vehiculo2 = null;
vehiculo3 = null;
auto1 = null;
auto2 = null;
autoElectrico = null;

GC.Collect();
GC.WaitForPendingFinalizers();
GC.Collect();

Console.WriteLine("\n\n--- Fin programa ---");
Console.ReadKey();
