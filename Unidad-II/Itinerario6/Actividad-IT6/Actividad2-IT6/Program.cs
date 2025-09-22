using Actividad2_IT6;

Console.Write("Desarrollar un programa que posea al menos una clase abstracta, un método virtual, una clase sellada y una clase anidada.\n\n");

Console.WriteLine("Creando Mago oscuro...");
Thread.Sleep(1000);

var darkMago = new MagoOscuro();
Console.WriteLine(darkMago.MostrarEstadisticas());
Thread.Sleep(1000);

Console.WriteLine("\nCreando Guerrero...");
Thread.Sleep(1000);

var guerrero = new Guerrero();
Console.WriteLine(guerrero.MostrarEstadisticas());

Console.ReadLine();