namespace CINESMART.Models
{
    // Modelo que representa una Película en el sistema
    public class Pelicula
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = "";

        public string Genero { get; set; } = "";

        public string Descripcion { get; set; } = "";

        public string SinopsisCompleta { get; set; } = "";

        public string Duracion { get; set; } = "";

        public string Clasificacion { get; set; } = "";

        public string Director { get; set; } = "";

        public string Reparto { get; set; } = "";

        public string Imagen { get; set; } = "";

        public double Calificacion { get; set; } = 4.8;
    }
}