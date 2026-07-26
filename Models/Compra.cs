namespace CINESMART.Models
{
    public class Compra
    {
        public int Id { get; set; }

        public string Cliente { get; set; } = "";

        public string Correo { get; set; } = "";

        public int FuncionId { get; set; }

        public string Pelicula { get; set; } = "";

        public string Fecha { get; set; } = "";

        public string Hora { get; set; } = "";

        public string Sala { get; set; } = "";

        public List<string> Asientos { get; set; } = new();

        public int CantidadEntradas { get; set; }

        public decimal PrecioEntradas { get; set; }

        public int? ComboId { get; set; }

        public string ComboNombre { get; set; } = "";

        public decimal PrecioCombos { get; set; }

        public decimal Total { get; set; }

        public string CodigoReserva { get; set; } = "";
    }
}