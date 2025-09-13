using System;
using System.ComponentModel;

namespace ActividadIntegradoraUnidad1
{
    class Auto : ICloneable
    {
        public string Patente { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Anio { get; set; }
        public Decimal Precio { get; set; }
        [Browsable(false)]
        public Persona Dueño { get; internal set; }

        public Auto(string Patente, string Marca, string Modelo, string anio, Decimal Precio)
        {
            this.Patente = Patente;
            this.Marca = Marca;
            this.Modelo = Modelo;
            this.Anio = anio;
            this.Precio = Precio;
        }

        ~Auto()
        {
            Console.WriteLine("Liberando legajo: " + this.Patente);
        }

        public object Clone() => this.MemberwiseClone();
        public Auto CloneTipado() => Clone() as Auto;

        public string ObtenerNombreDueño()
        {
            if (Dueño != null)
                return $"{Dueño.Apellido}, {Dueño.Nombre}";
            else
                return "Sin dueño";
        }

    }
}
