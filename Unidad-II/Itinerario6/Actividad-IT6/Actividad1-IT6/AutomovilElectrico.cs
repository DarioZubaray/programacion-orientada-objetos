namespace Actividad1_IT6
{
    internal class AutomovilElectrico : Automovil
    {
        #region Atributos
        private int autonomiaBaterias;
        private bool cargaRapida;
        #endregion

        #region Constructores
        public AutomovilElectrico(string marca, string modelo, int año, int autonomia, bool cargaRapida)
            : base(marca, modelo, año, 4, "Automática") // Llama al constructor de Automovil
        {
            Console.WriteLine("Constructor de AutomovilElectrico llamado");
            this.autonomiaBaterias = autonomia;
            this.cargaRapida = cargaRapida;
        }
        #endregion

        #region Finalizadores
        ~AutomovilElectrico()
        {
            Console.WriteLine($"Finalizador de AutomovilElectrico ejecutado para {marca} {modelo}");
        }
        #endregion

        #region Metodos
        public override void MostrarInformacion()
        {
            // Usa base para llamar al método de la clase padre (Automovil)
            base.MostrarInformacion();
            Console.WriteLine($"Autonomía: {this.autonomiaBaterias} km, Carga rápida: {(this.cargaRapida ? "Sí" : "No")}");
        }

        // Sobrescribe el método protegido con comportamiento específico
        protected override void IniciarMotor()
        {
            // No llama a base.IniciarMotor() porque los autos eléctricos no tienen motor tradicional
            Console.WriteLine("Iniciando sistema eléctrico...");
            Console.WriteLine("Verificando nivel de batería...");
            Console.WriteLine("Automóvil eléctrico listo!");
        }

        public AutomovilElectrico CargarBateria(int porcentajeCarga)
        {
            Console.WriteLine($"Cargando batería al {porcentajeCarga}%...");

            if (cargaRapida && porcentajeCarga > 80)
            {
                Console.WriteLine("Usando carga rápida para completar la batería");
            }
            return this;
        }
        #endregion
    }
}
