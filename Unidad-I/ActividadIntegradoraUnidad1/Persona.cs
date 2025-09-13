using System;
using System.Collections.Generic;

namespace ActividadIntegradoraUnidad1
{
    class Persona
    {
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        private List<Auto> _autos;

        public Persona(string DNI, string Nombre, string Apellido)
        {
            this.DNI = DNI;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this._autos = new List<Auto>();
        }

        ~Persona()
        {
            Console.WriteLine("Liberando legajo: " + this.DNI);
        }

        public void AgregarAuto(Auto auto)
        {
            if (!_autos.Contains(auto))
                _autos.Add(auto);
        }

        public List<Auto> ListaDeAutos()
        {
            List<Auto> aux = new List<Auto>();
            foreach (var auto  in _autos)
            {
                aux.Add(auto.CloneTipado());
            }
            return aux;
        }

        public int CantidadDeAutos()
        {
            return _autos.Count;
        }
    }
}
