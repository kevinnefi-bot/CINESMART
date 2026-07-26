using CINESMART.Models;

namespace CINESMART.Data
{
    // Clase de datos del proyecto (Programación Modular y Vectores de datos)
    public static class CineData
    {
        // 1. Lista de Películas
        public static List<Pelicula> Peliculas { get; } = new()
        {
            new Pelicula
            {
                Id = 1,
                Titulo = "Spider-Man: Brand New Day",
                Descripcion = "Peter Parker inicia un nuevo capítulo en Nueva York enfrentando nuevas amenazas urbanas.",
                SinopsisCompleta = "Después de los eventos multiversales, Peter Parker intenta reconstruir su vida en solitario. Sin embargo, una misteriosa organización emerge en Nueva York obligándolo a asumir la responsabilidad de proteger la ciudad una vez más.",
                Genero = "Acción",
                Duracion = "2h 25min",
                Clasificacion = "PG-13",
                Director = "Destin Daniel Cretton",
                Reparto = "Tom Holland, Zendaya, Sadik Sink",
                Imagen = "/images/spiderman_bnd.svg",
                Calificacion = 4.9
            },

            new Pelicula
            {
                Id = 2,
                Titulo = "The Backrooms",
                Descripcion = "Un joven fotógrafo cae accidentalmente en un laberinto infinito de pasillos amarillos.",
                SinopsisCompleta = "Basado en el fenómeno de internet. Un grupo de exploradores espaciales y científicos cruza sin querer el umbral de la realidad cayendo en The Backrooms, un laberinto interminable de oficinas vacías donde algo acecha en las sombras.",
                Genero = "Terror",
                Duracion = "1h 48min",
                Clasificacion = "16+",
                Director = "Kane Parsons",
                Reparto = "Kane Parsons, Mark Higgins, Sarah Paulson",
                Imagen = "/images/backrooms.svg",
                Calificacion = 4.7
            },

            new Pelicula
            {
                Id = 3,
                Titulo = "Avengers: Doomsday",
                Descripcion = "Los Vengadores se reúnen para enfrentar la amenaza definitiva del Doctor Doom.",
                SinopsisCompleta = "Ante el colapso inminente de múltiples realidades, los héroes más poderosos de la Tierra deben unirse con nuevos aliados para enfrentar a Victor Von Doom antes de que reescriba el universo a su voluntad.",
                Genero = "Acción",
                Duracion = "2h 55min",
                Clasificacion = "PG-13",
                Director = "Anthony y Joe Russo",
                Reparto = "Robert Downey Jr., Pedro Pascal, Chris Evans",
                Imagen = "/images/avengers_doomsday.svg",
                Calificacion = 5.0
            },

            new Pelicula
            {
                Id = 4,
                Titulo = "Zootopia 2",
                Descripcion = "Judy Hopps y Nick Wilde investigan un misterio que pone a prueba la ciudad de Zootopia.",
                SinopsisCompleta = "Los detectives Judy Hopps y Nick Wilde regresan para resolver el caso más peligroso e intrincado de sus carreras, siguiendo una pista de reptiles misteriosos que han llegado para alterar la armonía de Zootopia.",
                Genero = "Animación",
                Duracion = "1h 42min",
                Clasificacion = "ATP",
                Director = "Byron Howard, Rich Moore",
                Reparto = "Ginnifer Goodwin, Jason Bateman, Ke Huy Quan",
                Imagen = "/images/zootopia2.svg",
                Calificacion = 4.8
            },

            new Pelicula
            {
                Id = 5,
                Titulo = "Interestelar",
                Descripcion = "Un grupo de exploradores viaja a través de un agujero de gusano para salvar la humanidad.",
                SinopsisCompleta = "Al ver que la vida en la Tierra está llegando a su fin, un grupo de exploradores dirigidos por el piloto Cooper emprende la misión más importante de la historia de la humanidad: viajar más allá de nuestra galaxia.",
                Genero = "Ciencia ficción",
                Duracion = "2h 49min",
                Clasificacion = "PG-13",
                Director = "Christopher Nolan",
                Reparto = "Matthew McConaughey, Anne Hathaway, Jessica Chastain",
                Imagen = "/images/interstellar.svg",
                Calificacion = 4.9
            }
        };

        // 2. Lista de Funciones (Salas simples: Sala 1, Sala 2, Sala 3, Sala 4)
        public static List<Funcion> Funciones { get; } = new()
        {
            new Funcion { Id = 1, PeliculaId = 1, Fecha = "26/07/2026", Hora = "15:00", Sala = "Sala 1", Precio = 35 },
            new Funcion { Id = 2, PeliculaId = 1, Fecha = "26/07/2026", Hora = "19:00", Sala = "Sala 1", Precio = 35 },
            new Funcion { Id = 3, PeliculaId = 2, Fecha = "26/07/2026", Hora = "18:00", Sala = "Sala 2", Precio = 30 },
            new Funcion { Id = 4, PeliculaId = 2, Fecha = "26/07/2026", Hora = "21:30", Sala = "Sala 2", Precio = 30 },
            new Funcion { Id = 5, PeliculaId = 3, Fecha = "26/07/2026", Hora = "16:00", Sala = "Sala 3", Precio = 40 },
            new Funcion { Id = 6, PeliculaId = 3, Fecha = "26/07/2026", Hora = "20:00", Sala = "Sala 3", Precio = 40 },
            new Funcion { Id = 7, PeliculaId = 4, Fecha = "26/07/2026", Hora = "14:30", Sala = "Sala 4", Precio = 25 },
            new Funcion { Id = 8, PeliculaId = 5, Fecha = "26/07/2026", Hora = "17:30", Sala = "Sala 1", Precio = 35 }
        };

        // 3. Lista de Combos de Dulcería (Combos sencillos y claros)
        public static List<Combo> Combos { get; } = new()
        {
            new Combo { Id = 1, Nombre = "Combo Individual", Descripcion = "1 Palomita mediana + 1 Gaseosa.", Precio = 20 },
            new Combo { Id = 2, Nombre = "Combo para Dos", Descripcion = "1 Palomita grande + 2 Gaseosas.", Precio = 35 },
            new Combo { Id = 3, Nombre = "Combo Familiar", Descripcion = "2 Palomitas grandes + 4 Gaseosas + Nachos con queso.", Precio = 55 }
        };

        // 4. Historial de Reservas en memoria
        public static List<Compra> Reservas { get; } = new()
        {
            new Compra
            {
                Id = 1001,
                Cliente = "Kevin Balcazar",
                Correo = "kevin@ejemplo.com",
                FuncionId = 1,
                Pelicula = "Spider-Man: Brand New Day",
                Fecha = "26/07/2026",
                Hora = "15:00",
                Sala = "Sala 1",
                Asientos = new List<string> { "A1", "A2" },
                CantidadEntradas = 2,
                PrecioEntradas = 70,
                ComboId = 2,
                ComboNombre = "Combo para Dos",
                PrecioCombos = 35,
                Total = 105,
                CodigoReserva = "CS-884920"
            }
        };

        // Funciones auxiliares para demostrar programación modular en C#
        public static Pelicula? ObtenerPeliculaPorId(int id)
        {
            return Peliculas.FirstOrDefault(p => p.Id == id);
        }

        public static List<Funcion> ObtenerFuncionesPorPelicula(int peliculaId)
        {
            return Funciones.Where(f => f.PeliculaId == peliculaId).ToList();
        }

        public static Combo? ObtenerComboPorId(int? comboId)
        {
            if (!comboId.HasValue) return null;
            return Combos.FirstOrDefault(c => c.Id == comboId.Value);
        }
    }
}