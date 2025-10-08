namespace Actividad_IT9_2
{
    class ObjetoResucitable
    {
        // Referencia estática para permitir la "resurrección"
        public static ObjetoResucitable InstanciaResucitada;

        public int Valor { get; private set; }

        public ObjetoResucitable(int valor)
        {
            Valor = valor;
        }

        // Finalizador: se ejecuta cuando el GC detecta que ya no hay referencias activas
        ~ObjetoResucitable()
        {
            Console.WriteLine("Finalizador ejecutado. Resucitando objeto...");

            // "Resurrección": se asigna la referencia actual (this) a una variable estática
            InstanciaResucitada = this;
        }
    }
}
