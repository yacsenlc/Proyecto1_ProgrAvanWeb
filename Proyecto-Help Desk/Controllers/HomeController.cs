using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Proyecto_Help_Desk.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Help_Desk.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Usuario()
        {
            ViewBag.NombreUsuario = TempData["NombreUsuario"] ?? "Usuario";

            return View();
        }
        public IActionResult Especialista()
        {
            return View();
        }

        // Mostrar Login
        public IActionResult Login()
        {
            return View();
        }

        // Procesar Login
        [HttpPost]
        public IActionResult Login(string usuario, string password)
        {
            if (usuario == "yacsen" && password == "1234")
            {
                TempData["NombreUsuario"] = "Yacsen";

                return RedirectToAction("Usuario");
            }
            else if (usuario == "pablo" && password == "1234")
            {
                TempData["NombreUsuario"] = "Pablo";

                return RedirectToAction("Usuario");
            }
            else
            {
                ViewBag.Error = "Usuario o contraseña incorrectos.";

                return View();
            }
        }

        // Recuperar contraseña
        [HttpPost]
        public IActionResult RecuperarPassword(string correo)
        {
            // Aquí posteriormente se implementará el envío del correo.

            return RedirectToAction("Login");
        }

    }
}
