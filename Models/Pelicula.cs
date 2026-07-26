namespace CINESMART.Models
{
    public class Pelicula
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = "";

        public string Descripcion { get; set; } = "";

        public string Genero { get; set; } = "";

        public string Duracion { get; set; } = "";

        public string Clasificacion { get; set; } = "";

        public string Imagen { get; set; } = "";

        public bool Disponible { get; set; } = true;
    }
}