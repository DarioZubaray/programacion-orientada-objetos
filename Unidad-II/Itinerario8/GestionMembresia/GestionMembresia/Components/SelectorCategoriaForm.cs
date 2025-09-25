using GestionMembresia.Entities;

namespace GestionMembresia.Components
{
    // Componente Personalizado
    public partial class SelectorCategoriaForm : Form
    {
        // Propiedad para almacenar la categoría seleccionada
        internal Categoria Resultado { get; private set; }

        public SelectorCategoriaForm()
        {
            Text = "Seleccionar categoría";
            Size = new Size(300, 180);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            // Titulo
            var label = new Label
            {
                Text = "Elija el tipo de categoría:",
                Dock = DockStyle.Top,
                Padding = new Padding(10),
                TextAlign = ContentAlignment.MiddleLeft
            };

            // Selector
            var combo = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Dock = DockStyle.Top,
                Margin = new Padding(10),
                Items = { "Principiante", "Intermedio", "Avanzado" },
                SelectedIndex = 0
            };

            // Boton inferior Aceptar
            var botonAceptar = new Button
            {
                Text = "Aceptar",
                Dock = DockStyle.Bottom,
                Height = 35,
                Margin = new Padding(10)
            };

            botonAceptar.Click += (s, e) =>
            {
                Resultado = combo.SelectedItem switch
                {
                    "Principiante" => new Principiante(),
                    "Intermedio" => new Intermedio(),
                    "Avanzado" => new Avanzado(),
                    _ => null
                };
                DialogResult = DialogResult.OK;
            };

            // Contenedor para aplicar padding general
            var panelCentral = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };

            panelCentral.Controls.Add(combo);
            panelCentral.Controls.Add(label);

            Controls.Add(panelCentral);
            Controls.Add(botonAceptar);
        }
    }
}
