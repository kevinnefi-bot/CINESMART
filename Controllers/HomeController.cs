using CINESMART.Data;
using CINESMART.Models;
using Microsoft.AspNetCore.Mvc;

namespace CINESMART.Controllers
{
    // Controlador principal que administra las vistas y subprogramas del cine
    public class HomeController : Controller
    {
        // 1. Subprograma: Página de Inicio
        public IActionResult Index()
        {
            var destacadas = CineData.Peliculas.Take(3).ToList();
            return View(destacadas);
        }

        // 2. Subprograma: Cartelera completa con filtro por género
        public IActionResult Cartelera(string? genero)
        {
            var peliculas = CineData.Peliculas;
            if (!string.IsNullOrWhiteSpace(genero) && genero != "Todos")
            {
                peliculas = peliculas.Where(p => p.Genero.Equals(genero, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            ViewBag.GeneroSeleccionado = genero ?? "Todos";
            return View(peliculas);
        }

        // 3. Subprograma: Ficha Técnica y Detalles de Película
        public IActionResult Detalles(int id)
        {
            var pelicula = CineData.ObtenerPeliculaPorId(id);
            if (pelicula == null)
            {
                return NotFound();
            }

            ViewBag.Funciones = CineData.ObtenerFuncionesPorPelicula(id);
            return View(pelicula);
        }

        // 4. PASO 1 de Compra: Selección de Función, Cantidad de Boletos y Asientos
        public IActionResult Comprar(int id = 1)
        {
            var pelicula = CineData.ObtenerPeliculaPorId(id);
            if (pelicula == null)
            {
                return NotFound();
            }

            ViewBag.Funciones = CineData.ObtenerFuncionesPorPelicula(id);
            return View(pelicula);
        }

        // 5. PASO 2 de Compra: Selección opcional de Combos & Dulcería
        [HttpPost]
        public IActionResult AgregarCombo(
            string cliente,
            string correo,
            int funcionId,
            int cantidadEntradas,
            string? asientosSeleccionados)
        {
            var funcion = CineData.Funciones.FirstOrDefault(f => f.Id == funcionId);
            if (funcion == null) return NotFound();

            var pelicula = CineData.ObtenerPeliculaPorId(funcion.PeliculaId);
            if (pelicula == null) return NotFound();

            if (cantidadEntradas < 1) cantidadEntradas = 1;

            decimal subtotal = funcion.Precio * cantidadEntradas;

            List<string> listaAsientos = new();
            if (!string.IsNullOrWhiteSpace(asientosSeleccionados))
            {
                listaAsientos = asientosSeleccionados.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList();
            }

            // Datos temporales para la vista de selección de combo
            ViewBag.Cliente = cliente;
            ViewBag.Correo = correo;
            ViewBag.Funcion = funcion;
            ViewBag.Pelicula = pelicula;
            ViewBag.CantidadEntradas = cantidadEntradas;
            ViewBag.AsientosSeleccionados = string.Join(",", listaAsientos);
            ViewBag.Subtotal = subtotal;
            ViewBag.Combos = CineData.Combos;

            return View("AgregarCombo");
        }

        // 6. Procesa la reserva final y muestra el boleto digital con QR
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

            var pelicula = CineData.ObtenerPeliculaPorId(funcion.PeliculaId);
            if (pelicula == null) return NotFound();

            if (cantidadEntradas < 1) cantidadEntradas = 1;

            var combo = CineData.ObtenerComboPorId(comboId);
            decimal precioCombos = combo?.Precio ?? 0;
            decimal precioEntradas = funcion.Precio * cantidadEntradas;
            decimal total = precioEntradas + precioCombos;

            List<string> listaAsientos = new();
            if (!string.IsNullOrWhiteSpace(asientosSeleccionados))
            {
                listaAsientos = asientosSeleccionados.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList();
            }

            // Generación de código único de reserva (ej. CS-492019)
            string codigoGenerado = $"CS-{Random.Shared.Next(100000, 999999)}";

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
                CodigoReserva = codigoGenerado
            };

            // Guardar compra en la lista estática
            CineData.Reservas.Add(compra);

            return View("Confirmacion", compra);
        }

        // 7. Subprograma de Combos (Vista independiente de dulcería)
        public IActionResult Combos()
        {
            return View(CineData.Combos);
        }

        // 8. Subprograma: Panel de Administración para ver estadísticas del cine
        public IActionResult Admin()
        {
            ViewBag.TotalRecaudado = CineData.Reservas.Sum(r => r.Total);
            ViewBag.TotalBoletos = CineData.Reservas.Sum(r => r.CantidadEntradas);
            ViewBag.TotalReservas = CineData.Reservas.Count;

            return View(CineData.Reservas);
        }
    }
}