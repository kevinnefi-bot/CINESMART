namespace CINESMART.Models
{
    public class Asiento
    {
        public int Id { get; set; }

        public string Fila { get; set; } = "";

        public int Numero { get; set; }

        public bool Ocupado { get; set; }

        public string NombreCompleto =>
            $"{Fila}{Numero}";
    }
}