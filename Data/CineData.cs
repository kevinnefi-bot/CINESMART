using CINESMART.Models;

namespace CINESMART.Data
{
    public static class CineData
    {
        public static List<Pelicula> Peliculas { get; } = new()
        {
            new Pelicula
            {
                Id = 1,
                Titulo = "Avatar: El camino del agua",
                Descripcion = "Una aventura épica en el mundo de Pandora.",
                Genero = "Ciencia ficción",
                Duracion = "3h 12min",
                Clasificacion = "12+",
                Imagen = "avatar.jpg"
            },

            new Pelicula
            {
                Id = 2,
                Titulo = "Spider-Man: A través del Spider-Verso",
                Descripcion = "Miles Morales regresa para vivir una nueva aventura.",
                Genero = "Animación / Acción",
                Duracion = "2h 20min",
                Clasificacion = "7+",
                Imagen = "spiderman.jpg"
            },

            new Pelicula
            {
                Id = 3,
                Titulo = "Interestelar",
                Descripcion = "Un grupo de exploradores viaja más allá de nuestra galaxia.",
                Genero = "Ciencia ficción / Drama",
                Duracion = "2h 49min",
                Clasificacion = "13+",
                Imagen = "interestelar.jpg"
            },

            new Pelicula
            {
                Id = 4,
                Titulo = "Jurassic World",
                Descripcion = "Los dinosaurios vuelven a dominar la isla.",
                Genero = "Acción / Aventura",
                Duracion = "2h 4min",
                Clasificacion = "13+",
                Imagen = "jurassic.jpg"
            }
        };

        public static List<Funcion> Funciones { get; } = new()
        {
            new Funcion
            {
                Id = 1,
                PeliculaId = 1,
                Fecha = "26/07/2026",
                Hora = "15:00",
                Sala = "Sala 1",
                Precio = 35
            },

            new Funcion
            {
                Id = 2,
                PeliculaId = 1,
                Fecha = "26/07/2026",
                Hora = "19:00",
                Sala = "Sala 1",
                Precio = 35
            },

            new Funcion
            {
                Id = 3,
                PeliculaId = 2,
                Fecha = "26/07/2026",
                Hora = "16:30",
                Sala = "Sala 2",
                Precio = 30
            },

            new Funcion
            {
                Id = 4,
                PeliculaId = 2,
                Fecha = "26/07/2026",
                Hora = "20:30",
                Sala = "Sala 2",
                Precio = 30
            },

            new Funcion
            {
                Id = 5,
                PeliculaId = 3,
                Fecha = "26/07/2026",
                Hora = "17:00",
                Sala = "Sala 3",
                Precio = 35
            },

            new Funcion
            {
                Id = 6,
                PeliculaId = 4,
                Fecha = "26/07/2026",
                Hora = "21:00",
                Sala = "Sala 4",
                Precio = 30
            }
        };

        public static List<Combo> Combos { get; } = new()
        {
            new Combo
            {
                Id = 1,
                Nombre = "Combo Clásico",
                Descripcion = "Palomitas grandes + gaseosa grande.",
                Precio = 25
            },

            new Combo
            {
                Id = 2,
                Nombre = "Combo Pareja",
                Descripcion = "2 palomitas medianas + 2 gaseosas.",
                Precio = 40
            },

            new Combo
            {
                Id = 3,
                Nombre = "Combo Familiar",
                Descripcion = "Palomitas grandes + 4 gaseosas + nachos.",
                Precio = 60
            }
        };
    }
}