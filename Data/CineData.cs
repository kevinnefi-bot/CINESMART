using CINESMART.Models;

namespace CINESMART.Data
{
    // Clase estática que simula nuestra base de datos en memoria para el proyecto
    public static class CineData
    {
        public static List<Pelicula> Peliculas { get; } = new()
        {
            new Pelicula
            {
                Id = 1,
                Titulo = "Avatar: El camino del agua",
                Descripcion = "Jake Sully vive con su nueva familia en el planeta Pandora hasta que una amenaza regresa.",
                SinopsisCompleta = "Ambientada más de una década después de los acontecimientos de la primera película, Avatar: El camino del agua empieza a contar la historia de la familia Sully, los problemas que los persiguen, los esfuerzos que hacen para mantenerse a salvo, las batallas que libran para seguir con vida y las tragedias que sufren.",
                Genero = "Ciencia ficción",
                Duracion = "3h 12min",
                Clasificacion = "PG-13",
                Director = "James Cameron",
                Reparto = "Sam Worthington, Zoe Saldaña, Sigourney Weaver",
                Imagen = "/images/avatar.svg",
                Calificacion = 4.9
            },

            new Pelicula
            {
                Id = 2,
                Titulo = "Spider-Man: No Way Home",
                Descripcion = "Peter Parker busca la ayuda del Doctor Strange para restaurar su secreto, desatando el multiverso.",
                SinopsisCompleta = "Por primera vez en la historia cinematográfica de Spider-Man, nuestro héroe es desenmascarado y ya no puede separar su vida normal de los enormes riesgos de ser un súper héroe. Cuando le pide ayuda al Doctor Strange, los riesgos se vuelven aún más peligrosos.",
                Genero = "Acción",
                Duracion = "2h 28min",
                Clasificacion = "PG-13",
                Director = "Jon Watts",
                Reparto = "Tom Holland, Zendaya, Benedict Cumberbatch",
                Imagen = "/images/spiderman.svg",
                Calificacion = 4.8
            },

            new Pelicula
            {
                Id = 3,
                Titulo = "Inside Out 2",
                Descripcion = "Riley entra en la adolescencia y surgen nuevas emociones en el cuartel general.",
                SinopsisCompleta = "Intensa-Mente 2 de Disney y Pixar vuelve a la mente de la recién nacida adolescente Riley justo cuando el cuartel general está sufriendo una repentina demolición para hacer espacio a algo totalmente inesperado: ¡nuevas emociones! Alegría, Tristeza, Furia, Temor y Desagrado no están seguros de cómo sentirse cuando aparece Ansiedad.",
                Genero = "Animación",
                Duracion = "1h 36min",
                Clasificacion = "ATP",
                Director = "Kelsey Mann",
                Reparto = "Amy Poehler, Maya Hawke, Kensington Tallman",
                Imagen = "/images/insideout.svg",
                Calificacion = 4.7
            },

            new Pelicula
            {
                Id = 4,
                Titulo = "Interestelar",
                Descripcion = "Un equipo de exploradores viaja a través de un agujero de gusano en el espacio en un intento por asegurar la supervivencia de la humanidad.",
                SinopsisCompleta = "Al ver que la vida en la Tierra está llegando a su fin, un grupo de exploradores dirigidos por el piloto Cooper emprende la misión más importante de la historia de la humanidad: viajar más allá de nuestra galaxia para descubrir si las estrellas albergan un futuro para la raza humana.",
                Genero = "Ciencia ficción",
                Duracion = "2h 49min",
                Clasificacion = "PG-13",
                Director = "Christopher Nolan",
                Reparto = "Matthew McConaughey, Anne Hathaway, Jessica Chastain",
                Imagen = "/images/interstellar.svg",
                Calificacion = 5.0
            },

            new Pelicula
            {
                Id = 5,
                Titulo = "Jurassic World",
                Descripcion = "Un parque temático de dinosaurios en una isla cae en el caos cuando un espécimen modificado se escapa.",
                SinopsisCompleta = "Veintidós años después de los eventos de Jurassic Park, la isla Nublar cuenta ahora con un parque temático de dinosaurios completamente funcional, Jurassic World, tal como lo había visionado John Hammond. Sin embargo, los científicos crean un dinosaurio genéticamente modificado que escapa del recinto.",
                Genero = "Acción",
                Duracion = "2h 04min",
                Clasificacion = "PG-13",
                Director = "Colin Trevorrow",
                Reparto = "Chris Pratt, Bryce Dallas Howard, Irrfan Khan",
                Imagen = "/images/jurassic.svg",
                Calificacion = 4.6
            }
        };

        public static List<Funcion> Funciones { get; } = new()
        {
            new Funcion { Id = 1, PeliculaId = 1, Fecha = "26/07/2026", Hora = "15:00", Sala = "Sala 1 (IMAX)", Precio = 35 },
            new Funcion { Id = 2, PeliculaId = 1, Fecha = "26/07/2026", Hora = "19:00", Sala = "Sala 1 (IMAX)", Precio = 35 },
            new Funcion { Id = 3, PeliculaId = 2, Fecha = "26/07/2026", Hora = "16:30", Sala = "Sala 2 (3D)", Precio = 30 },
            new Funcion { Id = 4, PeliculaId = 2, Fecha = "26/07/2026", Hora = "20:30", Sala = "Sala 2 (3D)", Precio = 30 },
            new Funcion { Id = 5, PeliculaId = 3, Fecha = "26/07/2026", Hora = "14:00", Sala = "Sala 3 (2D)", Precio = 25 },
            new Funcion { Id = 6, PeliculaId = 3, Fecha = "26/07/2026", Hora = "17:00", Sala = "Sala 3 (2D)", Precio = 25 },
            new Funcion { Id = 7, PeliculaId = 4, Fecha = "26/07/2026", Hora = "21:00", Sala = "Sala VIP 4", Precio = 45 },
            new Funcion { Id = 8, PeliculaId = 5, Fecha = "26/07/2026", Hora = "18:00", Sala = "Sala 5", Precio = 30 }
        };

        public static List<Combo> Combos { get; } = new()
        {
            new Combo { Id = 1, Nombre = "Combo Clásico", Descripcion = "1 Palomita Grande + 1 Gaseosa 32oz.", Precio = 25 },
            new Combo { Id = 2, Nombre = "Combo Pareja", Descripcion = "2 Palomitas Medianas + 2 Gaseosas + 1 Nachos con queso.", Precio = 40 },
            new Combo { Id = 3, Nombre = "Combo Familiar", Descripcion = "1 Palomita Gigante + 4 Gaseosas + 2 Nachos + 1 Dulce.", Precio = 60 }
        };

        // Historial de compras/reservas en memoria
        public static List<Compra> Reservas { get; } = new()
        {
            new Compra
            {
                Id = 1001,
                Cliente = "Kevin Balcazar",
                Correo = "kevin@ejemplo.com",
                FuncionId = 1,
                Pelicula = "Avatar: El camino del agua",
                Fecha = "26/07/2026",
                Hora = "15:00",
                Sala = "Sala 1 (IMAX)",
                Asientos = new List<string> { "A1", "A2" },
                CantidadEntradas = 2,
                PrecioEntradas = 70,
                ComboId = 1,
                ComboNombre = "Combo Clásico",
                PrecioCombos = 25,
                Total = 95,
                CodigoReserva = "CS-884920"
            }
        };
    }
}