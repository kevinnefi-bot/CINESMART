using CINESMART.Data;
using CINESMART.Models;
using Microsoft.AspNetCore.Mvc;

namespace CINESMART.Controllers
{
    // Controlador principal en C# con subprogramas sencillos y modularidad
    public class HomeController : Controller
    {
        // 1. Subprograma: Inicio
        public IActionResult Index()
        {
            var destacadas = CineData.Peliculas.Take(3).ToList();
            return View(destacadas);
        }

        // 2. Subprograma: Cartelera con filtro por género
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

        // 3. Subprograma: Detalles de Película
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

        // 4. PASO 1 de Compra: Entradas + Asientos + Datos
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

        // 5. PASO 2 de Compra: Selección de Combos de comida con fotos reales
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

        // 6. Procesa la reserva final y emite el boleto con QR
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

            CineData.Reservas.Add(compra);

            return View("Confirmacion", compra);
        }

        // 7. Subprograma: Combos & Dulcería (Vista independiente)
        public IActionResult Combos()
        {
            return View(CineData.Combos);
        }

        // 8. Subprograma: Login de Usuarios (Sencillo y para estudiantes)
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string usuario, string clave)
        {
            // Verificación limpia de usuario
            if (usuario == "admin" && clave == "1234")
            {
                HttpContext.Session.SetString("Usuario", "Administrador");
                return RedirectToAction("Admin");
            }
            else if (usuario == "kevin" && clave == "1234")
            {
                HttpContext.Session.SetString("Usuario", "Kevin Balcazar");
                return RedirectToAction("Index");
            }

            ViewBag.Error = "Usuario o contraseña incorrectos. Intenta con kevin / 1234 o admin / 1234";
            return View();
        }

        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        // 9. Subprograma: Panel de Administración
        public IActionResult Admin()
        {
            // Validar si es administrador
            var usuario = HttpContext.Session.GetString("Usuario");
            if (usuario != "Administrador")
            {
                ViewBag.MensajeAdmin = "Ingresa con el usuario de administrador (admin / 1234) para gestionar el panel.";
            }

            ViewBag.TotalRecaudado = CineData.Reservas.Sum(r => r.Total);
            ViewBag.TotalBoletos = CineData.Reservas.Sum(r => r.CantidadEntradas);
            ViewBag.TotalReservas = CineData.Reservas.Count;

            return View(CineData.Reservas);
        }
    }
}