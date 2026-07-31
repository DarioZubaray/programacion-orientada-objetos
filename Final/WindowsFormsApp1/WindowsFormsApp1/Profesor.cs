using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Profesor : Persona
    {
        public Profesor(string nombre)
        {
            this.Nombre = nombre;
        }

        public override void Saludar()
        {
            MessageBox.Show($"Profesor: {Nombre}");
        }
    }
}
