using CINESMART.Data;
using CINESMART.Models;
using Microsoft.AspNetCore.Mvc;

namespace CINESMART.Controllers
{
    public class HomeController : Controller
    {
        // 1. Página de Inicio: Muestra las primeras 3 películas destacadas
        public IActionResult Index()
        {
            var destacadas = CineData.Peliculas.Take(3).ToList();
            return View(destacadas);
        }

        // 2. Cartelera: Lista de películas con soporte para filtro por género
        public IActionResult Cartelera(string? genero)
        {
            var peliculas = CineData.Peliculas;
            if (!string.IsNullOrEmpty(genero) && genero != "Todos")
            {
                peliculas = peliculas.Where(p => p.Genero.Contains(genero, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            ViewBag.GeneroSeleccionado = genero ?? "Todos";
            return View(peliculas);
        }

        // 3. Detalles de Película: Vista con sinopsis completa, reparto y trailer simulado
        public IActionResult Detalles(int id)
        {
            var pelicula = CineData.Peliculas.FirstOrDefault(p => p.Id == id);
            if (pelicula == null)
            {
                return NotFound();
            }
            ViewBag.Funciones = CineData.Funciones.Where(f => f.PeliculaId == id).ToList();
            return View(pelicula);
        }

        // 4. Seccion de Combos & Dulceria
        public IActionResult Combos()
        {
            return View(CineData.Combos);
        }

        // 5. Formulario para Comprar Entradas
        public IActionResult Comprar(int id = 1)
        {
            var pelicula = CineData.Peliculas.FirstOrDefault(p => p.Id == id);
            if (pelicula == null)
            {
                return NotFound();
            }

            ViewBag.Funciones = CineData.Funciones.Where(f => f.PeliculaId == id).ToList();
            ViewBag.Combos = CineData.Combos;

            return View(pelicula);
        }

        // 6. Procesa la reserva y guarda la compra en memoria
        [HttpPost]
        public IActionResult ConfirmarCompra(
            string cliente,
            string correo,
            int funcionId,
            int cantidadEntradas,
            string? asientosSeleccionados,
            int? comboId)
        {
            var funcion = CineData.Funciones.FirstOrDefault(f => f.Id == funcionId);
            if (funcion == null) return NotFound();

            var pelicula = CineData.Peliculas.FirstOrDefault(p => p.Id == funcion.PeliculaId);
            if (pelicula == null) return NotFound();

            if (cantidadEntradas < 1) cantidadEntradas = 1;

            var combo = CineData.Combos.FirstOrDefault(c => c.Id == comboId);
            decimal precioCombos = combo?.Precio ?? 0;
            decimal precioEntradas = funcion.Precio * cantidadEntradas;
            decimal total = precioEntradas + precioCombos;

            List<string> listaAsientos = new();
            if (!string.IsNullOrWhiteSpace(asientosSeleccionados))
            {
                listaAsientos = asientosSeleccionados.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList();
            }

            var compra = new Compra
            {
                Id = Random.Shared.Next(1000, 9999),
                Cliente = cliente,
                Correo = correo,
                FuncionId = funcion.Id,
                Pelicula = pelicula.Titulo,
                Fecha = funcion.Fecha,
                Hora = funcion.Hora,
                Sala = funcion.Sala,
                Asientos = listaAsientos,
                CantidadEntradas = cantidadEntradas,
                PrecioEntradas = precioEntradas,
                ComboId = comboId,
                ComboNombre = combo?.Nombre ?? "Sin combo",
                PrecioCombos = precioCombos,
                Total = total,
                CodigoReserva = $"CS-{Random.Shared.Next(100000, 999999)}"
            };

            // Guardar en nuestra lista estática de reservas
            CineData.Reservas.Add(compra);

            return View("Confirmacion", compra);
        }

        // 7. Buscador de Reservas por Código (ej. CS-884920)
        public IActionResult BuscarReserva(string? codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
            {
                return View((Compra?)null);
            }

            var reserva = CineData.Reservas.FirstOrDefault(r => 
                r.CodigoReserva.Equals(codigo.Trim(), StringComparison.OrdinalIgnoreCase));
            
            ViewBag.CodigoBuscado = codigo;
            return View(reserva);
        }

        // 8. Subprograma / Panel Administrador para ver ventas y estadísticas del cine
        public IActionResult Admin()
        {
            ViewBag.TotalRecaudado = CineData.Reservas.Sum(r => r.Total);
            ViewBag.TotalBoletos = CineData.Reservas.Sum(r => r.CantidadEntradas);
            ViewBag.TotalReservas = CineData.Reservas.Count;

            return View(CineData.Reservas);
        }
    }
}