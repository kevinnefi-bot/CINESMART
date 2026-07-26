namespace CINESMART.Models
{
    public class CompraViewModel
    {
        public int PeliculaId { get; set; }

        public int FuncionId { get; set; }

        public string Pelicula { get; set; } = "";

        public string Fecha { get; set; } = "";

        public string Hora { get; set; } = "";

        public string Sala { get; set; } = "";

        public decimal PrecioEntrada { get; set; }

        public int CantidadEntradas { get; set; } = 1;

        public List<string> AsientosSeleccionados { get; set; } = new();

        public List<Combo> Combos { get; set; } = new();

        public string Cliente { get; set; } = "";

        public string Correo { get; set; } = "";

        public decimal TotalEntradas =>
            PrecioEntrada * CantidadEntradas;
    }
}