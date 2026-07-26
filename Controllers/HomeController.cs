using CINESMART.Data;
using CINESMART.Models;
using Microsoft.AspNetCore.Mvc;

namespace CINESMART.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(CineData.Peliculas.Take(3).ToList());
        }

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

        public IActionResult Combos()
        {
            return View(CineData.Combos);
        }

        public IActionResult Comprar(int id = 1)
        {
            var pelicula = CineData.Peliculas.FirstOrDefault(p => p.Id == id);

            if (pelicula == null)
            {
                return NotFound();
            }

            var funciones = CineData.Funciones.Where(f => f.PeliculaId == id).ToList();

            ViewBag.Funciones = funciones;
            ViewBag.Combos = CineData.Combos;

            return View(pelicula);
        }

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

            if (funcion == null)
            {
                return NotFound();
            }

            var pelicula = CineData.Peliculas.FirstOrDefault(p => p.Id == funcion.PeliculaId);

            if (pelicula == null)
            {
                return NotFound();
            }

            if (cantidadEntradas < 1)
            {
                cantidadEntradas = 1;
            }

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

            return View("Confirmacion", compra);
        }
    }
}