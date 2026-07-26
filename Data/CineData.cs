using CINESMART.Models;

namespace CINESMART.Data
{
    // Clase de datos principal (Programación Modular en C#)
    public static class CineData
    {
        // 1. Catálogo de Películas con fotos reales
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
                Reparto = "Tom Holland, Zendaya, Sadie Sink",
                Imagen = "https://images.unsplash.com/photo-1635805737707-575885ab0820?w=600&auto=format&fit=crop&q=80",
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
                Imagen = "https://images.unsplash.com/photo-1509198397868-475647b2a1e5?w=600&auto=format&fit=crop&q=80",
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
                Imagen = "https://images.unsplash.com/photo-1607604276583-eef5d076aa5f?w=600&auto=format&fit=crop&q=80",
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
                Imagen = "https://images.unsplash.com/photo-1534447677768-be436bb09401?w=600&auto=format&fit=crop&q=80",
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
                Imagen = "https://images.unsplash.com/photo-1451187580459-43490279c0fa?w=600&auto=format&fit=crop&q=80",
                Calificacion = 4.9
            }
        };

        // 2. Funciones de Cine (Salas 1, 2, 3, 4)
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

        // 3. Catálogo de Combos con fotos reales de pipocas y refrescos
        public static List<Combo> Combos { get; } = new()
        {
            new Combo 
            { 
                Id = 1, 
                Nombre = "Combo Individual", 
                Descripcion = "1 Pipoca mediana crujiente + 1 Refresco helado de 32oz.", 
                Precio = 20,
                Imagen = "https://images.unsplash.com/photo-1585647347483-22b66260dfff?w=600&auto=format&fit=crop&q=80"
            },
            new Combo 
            { 
                Id = 2, 
                Nombre = "Combo para Dos", 
                Descripcion = "1 Pipoca grande mantecosa + 2 Refrescos helados a elección.", 
                Precio = 35,
                Imagen = "https://images.unsplash.com/photo-1578849278619-e73505e9610f?w=600&auto=format&fit=crop&q=80"
            },
            new Combo 
            { 
                Id = 3, 
                Nombre = "Combo Familiar", 
                Descripcion = "2 Pipocas grandes + 4 Refrescos + Nachos calientes con queso cheddar.", 
                Precio = 55,
                Imagen = "https://images.unsplash.com/photo-1513104890138-7c749659a591?w=600&auto=format&fit=crop&q=80"
            }
        };

        // 4. Reservas de compras
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

        // Funciones modulares
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