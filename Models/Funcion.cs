namespace CINESMART.Models
{
    public class Funcion
    {
        public int Id { get; set; }

        public int PeliculaId { get; set; }

        public string Fecha { get; set; } = "";

        public string Hora { get; set; } = "";

        public string Sala { get; set; } = "";

        public decimal Precio { get; set; }

        public Pelicula? Pelicula { get; set; }
    }
}