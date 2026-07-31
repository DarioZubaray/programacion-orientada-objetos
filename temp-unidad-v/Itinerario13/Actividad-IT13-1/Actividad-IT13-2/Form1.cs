namespace Actividad_IT12_2
{
    public partial class Form1 : Form
    {
        private List<Persona> personas;
        public Form1()
        {
            InitializeComponent();
            personas = new List<Persona>() 
            {
                new Persona(){ Nombre = "Ana", Edad = 20, Ciudad = "Buenos Aires" },
                new Persona(){ Nombre = "Pedro", Edad = 28, Ciudad = "Santa Fe" },
                new Persona(){ Nombre = "Maria", Edad = 32, Ciudad = "Buenos Aires" },
                new Persona(){ Nombre = "José", Edad = 33, Ciudad = "Cordoba" },
                new Persona(){ Nombre = "Carlos", Edad = 23, Ciudad = "La Pampa" },
                new Persona(){ Nombre = "Juana", Edad = 30, Ciudad = "Buenos Aires" },
                new Persona(){ Nombre = "Abel", Edad = 25, Ciudad = "Santa Fe" },
            };
            dataGridView1.DataSource = personas;
        }

        private void RefreshDataGridView(DataGridView pDGV, object pO)
        {
            pDGV.DataSource = null; pDGV.DataSource = pO;
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            var atributo = comboBoxAtributo.Text;
            var condicion = comboBoxCondicion.Text;
            var valor = textBoxValor.Text;

            var resultado = Filtrar(personas, atributo, condicion, valor);

            RefreshDataGridView(dataGridView1, resultado.ToList());
        }

        private IEnumerable<Persona> Filtrar(IEnumerable<Persona> personas, string atributo, string condicion, string valor)
        {
            // Normalizar valores a minúsculas
            atributo = atributo.ToLower();
            condicion = condicion.ToLower();

            // Elegir lógica según atributo(nombre-edad-ciudad)
            switch (atributo)
            {
                case "nombre":
                    return AplicarCondicionTexto(personas, p => p.Nombre, condicion, valor);

                case "ciudad":
                    return AplicarCondicionTexto(personas, p => p.Ciudad, condicion, valor);

                case "edad":
                    // Intentar convertir el valor a número
                    if (int.TryParse(valor, out int edad))
                        return AplicarCondicionNumerica(personas, p => p.Edad, condicion, edad);
                    else
                        MessageBox.Show("El valor para 'Edad' debe ser numérico.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }

            return personas; // sin filtro si no coincide o la edad no es un número
        }

        // Versión genérica para strings
        private IEnumerable<Persona> AplicarCondicionTexto(IEnumerable<Persona> personas, Func<Persona, string> selector, string condicion, string valor)
        {
            switch (condicion)
            {
                case "es":
                    return personas.Where(p => string.Equals(selector(p), valor, StringComparison.OrdinalIgnoreCase));
                case "no es":
                    return personas.Where(p => !string.Equals(selector(p), valor, StringComparison.OrdinalIgnoreCase));
                default:
                    return personas; // Condiciones es menor y es mayor para texto no se aplican filtros.
            }
        }

        // Versión genérica para enteros
        private IEnumerable<Persona> AplicarCondicionNumerica(IEnumerable<Persona> personas, Func<Persona, int> selector, string condicion, int valor)
        {
            return condicion switch
            {
                "es" => personas.Where(p => selector(p) == valor),
                "no es" => personas.Where(p => selector(p) != valor),
                "es menor" => personas.Where(p => selector(p) < valor),
                "es mayor" => personas.Where(p => selector(p) > valor),
                _ => personas
            };
        }
    }
}
