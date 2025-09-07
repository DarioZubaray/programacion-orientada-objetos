using System;
using System.Collections.Generic;

namespace TPI1_Itinerario4
{
    class Alumno : ICloneable
    {
        public int Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        private DateTime _fechaNacimiento { get; set; }
        public DateTime FechaNacimiento { set { _fechaNacimiento = value; } }
        private DateTime _fechaIngreso { get; set; }
        public DateTime FechaIngreso { set { _fechaIngreso = value; } }
        public int Edad { get; }
        public bool Activo { get; set; }
        private int _cantMateriasAprobadas { get; set; }
        public int CantMateriaAprobadas { set { _cantMateriasAprobadas = value; } }

        public Alumno() { }
        public Alumno(int legajo, string nombre, string apellido, DateTime fechaNacimiento)
        {
            Legajo = legajo;
            Nombre = nombre;
            Apellido = apellido;
            _fechaNacimiento = fechaNacimiento;
            _fechaIngreso = DateTime.Now;
            Edad = (int)((DateTime.Now - fechaNacimiento).Days / 365.25);
            Activo = true;
            _cantMateriasAprobadas = 0;
        }

        ~Alumno()
        {
            Console.WriteLine("Liberando legajo: " + this.Legajo);
        }

        public string NombreCompleto()
        {
            return $"{Nombre} {Apellido}";
        }

        public int Antiguedad(string unidad)
        {
            DateTime hoy = DateTime.Today;
            TimeSpan diferencia = hoy - _fechaIngreso;

            switch (unidad.ToLower())
            {
                case "d":
                case "dias":
                    return diferencia.Days;
                case "m":
                case "meses":
                    return (int)(diferencia.TotalDays / 30);
                case "y":
                case "años":
                    return (int)(diferencia.TotalDays / 365.25);

                default:
                    return 0;
            }
        }

        public int MateriasNoAprobadas()
        {
            int TotalMaterias = 36; // Este dato depende de la carrera. Por ahora aqui esta bien
            return TotalMaterias - _cantMateriasAprobadas;
        }

        public int EdadDeIngreso()
        {
            return (int)Math.Round((_fechaIngreso - _fechaNacimiento).TotalDays / 365.25);
        }

        public object Clone() => this.MemberwiseClone();
        public Alumno CloneTipado() => Clone() as Alumno;

        public static List<Alumno> CopiaListaAlumnos(List<Alumno> alumnos)
        {
            List<Alumno> aux = new List<Alumno>();
            foreach (var alumno in alumnos)
            {
                aux.Add(alumno.CloneTipado());
            }
            return aux;
        }
    }
}
