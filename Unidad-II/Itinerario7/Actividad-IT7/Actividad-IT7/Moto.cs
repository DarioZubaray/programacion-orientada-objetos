namespace Actividad_IT7
{
    internal class Moto : Vehiculo
    {
        #region Atributos
        private int Cilindrada;
        private bool TieneBaul;
        #endregion

        #region Constructores y Finalizadores
        // Constructor usando 'base'
        public Moto(string marca, string modelo, int anio, int cilindrada)
            : base(marca, modelo, anio)
        {
            Console.WriteLine("Constructor derivado: Moto(marca,modelo,anio,cilindrada) [4 parametros]");
            this.Cilindrada = cilindrada;
            this.TieneBaul = false;
        }

        ~Moto()
        {
            Console.WriteLine($"Finalizador derivado: ~Moto() - Cilindrada: {Cilindrada}cc");
        }
        #endregion

        #region Metodos
        public override void MostrarInformacion()
        {
            base.MostrarInformacion();  // Llama a la implementacion base
            Console.WriteLine($"\tCilindrada: {this.Cilindrada}cc");
            Console.WriteLine($"\tTiene Baul: {(this.TieneBaul ? "Sí" : "No")}");
        }
        #endregion
    }
}
