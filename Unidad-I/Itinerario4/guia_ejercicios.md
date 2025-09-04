# Guía de ejercicios

1. Desarrollar un programa que posea una clase que aplique un destructor que finalice el ciclo de vida de un objeto que se instanció en el constructor.

```C#
using System;

public class Recurso : IDisposable
{
    // Un recurso que necesita ser limpiado manualmente
    private ConexionRed _conexionRed;

    // Constructor
    public Recurso()
    {
        Console.WriteLine("Constructor: Se ha creado el objeto y se ha abierto un recurso.");
        _conexionRed = ConexionRed.Abrir();
    }

    // Destructor
    ~Recurso()
    {
        Console.WriteLine("Destructor: Se va a destruir el objeto y se va cerrar el recurso.");
        _conexionRed = ConexionRed.Cerrar();
    }

}
```