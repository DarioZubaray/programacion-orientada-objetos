public class CodigoAccionParser : ICodigoAccionParser
{
    public IEnumerable<string> ObtenerPartes(string codigo)
    {
        return codigo.Split('-');
    }
}
