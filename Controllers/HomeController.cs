// Clean HomeController – single definition
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CINESMART.Data;
using CINESMART.Models;

namespace CINESMART.Controllers
{
    public class HomeController : Controller
    {
        // 1. Inicio – muestra 3 películas destacadas
        public IActionResult Index()
        {
            var destacadas = CineData.Peliculas.Take(3).ToList();
            return View(destacadas);
        }

        // 2. Cartelera con filtro por género
        public IActionResult Cartelera(string? genero)
        {
            var peliculas = CineData.Peliculas;
            if (!string.IsNullOrWhiteSpace(genero) && genero != "Todos")
            {
                peliculas = peliculas
                    .Where(p => p.Genero.Equals(genero, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            ViewBag.GeneroSeleccionado = genero ?? "Todos";
            return View(peliculas);
        }

        // 3. Detalles de película
        public IActionResult Detalles(int id)
        {
            var pelicula = CineData.ObtenerPeliculaPorId(id);
            if (pelicula == null) return NotFound();
            ViewBag.Funciones = CineData.ObtenerFuncionesPorPelicula(id);
            return View(pelicula);
        }

        // 4. Paso 1 de compra – elegir función y asientos
        public IActionResult Comprar(int id = 1)
        {
            var pelicula = CineData.ObtenerPeliculaPorId(id);
            if (pelicula == null) return NotFound();
            ViewBag.Funciones = CineData.ObtenerFuncionesPorPelicula(id);
            return View(pelicula);
        }

        // 5. Paso 2 de compra – seleccionar combos (fotos reales)
        [HttpPost]
        public IActionResult AgregarCombo(string cliente, string correo,
            int funcionId, int cantidadEntradas, string? asientosSeleccionados)
        {
            var funcion = CineData.Funciones.FirstOrDefault(f => f.Id == funcionId);
            if (funcion == null) return NotFound();

            var pelicula = CineData.ObtenerPeliculaPorId(funcion.PeliculaId);
            if (pelicula == null) return NotFound();

            if (cantidadEntradas < 1) cantidadEntradas = 1;
            var subtotal = funcion.Precio * cantidadEntradas;

            var listaAsientos = string.IsNullOrWhiteSpace(asientosSeleccionados)
                ? new List<string>()
                : asientosSeleccionados.Split(',', StringSplitOptions.RemoveEmptyEntries
                                             | StringSplitOptions.TrimEntries).ToList();

            ViewBag.Cliente = cliente;
            ViewBag.Correo = correo;
            ViewBag.Funcion = funcion;
            ViewBag.Pelicula = pelicula;
            ViewBag.CantidadEntradas = cantidadEntradas;
            ViewBag.AsientosSeleccionados = string.Join(",", listaAsientos);
            ViewBag.Subtotal = subtotal;
            ViewBag.Combos = CineData.Combos; // <-- aquí tienes las imágenes reales de los combos
            return View("AgregarCombo");
        }

        // 6. Confirmar compra – genera QR y guarda reserva
        [HttpPost]
        public IActionResult ConfirmarCompra(string cliente, string correo,
            int funcionId, int cantidadEntradas, string? asientosSeleccionados, int? comboId)
        {
            var funcion = CineData.Funciones.FirstOrDefault(f => f.Id == funcionId);
            if (funcion == null) return NotFound();

            var pelicula = CineData.ObtenerPeliculaPorId(funcion.PeliculaId);
            if (pelicula == null) return NotFound();

            if (cantidadEntradas < 1) cantidadEntradas = 1;
            var combo = CineData.ObtenerComboPorId(comboId);
            var precioCombos = combo?.Precio ?? 0;
            var precioEntradas = funcion.Precio * cantidadEntradas;
            var total = precioEntradas + precioCombos;

            var listaAsientos = string.IsNullOrWhiteSpace(asientosSeleccionados)
                ? new List<string>()
                : asientosSeleccionados.Split(',', StringSplitOptions.RemoveEmptyEntries
                                             | StringSplitOptions.TrimEntries).ToList();

            var codigoGenerado = $"CS-{Random.Shared.Next(100000, 999999)}";

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

        // 7. Vista de combos
        public IActionResult Combos()
        {
            return View(CineData.Combos);
        }

        // 8. Login (GET)
        public IActionResult Login()
        {
            return View();
        }

        // 9. Login (POST)
        [HttpPost]
        public IActionResult Login(string correo, string clave)
        {
            var usuario = CineData.ValidarLogin(correo, clave);
            if (usuario != null)
            {
                HttpContext.Session.SetString("Usuario", usuario.Nombre);
                HttpContext.Session.SetString("Rol", usuario.Rol);
                return usuario.Rol == "admin" ? RedirectToAction("Admin") : RedirectToAction("Index");
            }
            ViewBag.Error = "Correo o contraseña incorrectos. Usa admin@cinesmart.com / admin123 o kevin@correo.com / 1234";
            return View();
        }

        // 10. Cerrar sesión
        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        // 11. Registro (GET)
        public IActionResult Register()
        {
            return View();
        }

        // 12. Registro (POST)
        [HttpPost]
        public IActionResult Register(string nombre, string correo, string clave)
        {
            bool ok = CineData.RegistrarUsuario(nombre, correo, clave);
            if (ok)
            {
                HttpContext.Session.SetString("Usuario", nombre);
                HttpContext.Session.SetString("Rol", "cliente");
                return RedirectToAction("Index");
            }
            ViewBag.Error = "El correo ya está registrado. Por favor usa otro.";
            return View();
        }

        // 13. Panel de administración (admin only)
        public IActionResult Admin()
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (rol != "admin")
                return RedirectToAction("Login");

            ViewBag.TotalRecaudado = CineData.Reservas.Sum(r => r.Total);
            ViewBag.TotalBoletos   = CineData.Reservas.Sum(r => r.CantidadEntradas);
            ViewBag.TotalReservas  = CineData.Reservas.Count;
            return View(CineData.Reservas);
        }
    }
}   