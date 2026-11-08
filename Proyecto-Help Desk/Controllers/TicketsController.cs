
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto_Help_Desk.Data;
using Proyecto_Help_Desk.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Help_Desk.Controllers
{
    public class TicketsController : Controller
    {
        private readonly HelpDeskContext _context;

        public TicketsController(HelpDeskContext context)
        {
            _context = context;
        }

        // Mostrar formulario para crear ticket

        // Mostrar formulario Crear Ticket
        [HttpGet]
        public async Task<IActionResult> Crear()
        {
            await CargarCategorias();

            return View();
        }


        // Guardar ticket en SQL Server
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Ticket ticket)
        {
            // Quitar validaciones de las relaciones
            ModelState.Remove("UsuarioCreador");
            ModelState.Remove("TecnicoAsignado");
            ModelState.Remove("Categoria");
            ModelState.Remove("Estado");
            ModelState.Remove("Comentarios");

            // Obtener estado Abierto
            var estadoAbierto = await _context.Estados
                .FirstOrDefaultAsync(e => e.Nombre == "Abierto");

            if (estadoAbierto == null)
            {
                ModelState.AddModelError("",
                    "No existe el estado Abierto.");
            }
            else
            {
                ticket.IdEstado = estadoAbierto.IdEstado;
            }

            // Fecha de creación
            ticket.FechaCreacion = DateTime.Now;

            // Sin técnico asignado
            ticket.IdTecnico = null;

            if (!ModelState.IsValid)
            {
                await CargarCategorias();
                return View(ticket);
            }

            // Verificar categoría
            bool categoriaExiste = await _context.Categorias
                .AnyAsync(c => c.IdCategoria == ticket.IdCategoria);

            if (!categoriaExiste)
            {
                ModelState.AddModelError("IdCategoria",
                    "La categoría seleccionada no existe.");

                await CargarCategorias();
                return View(ticket);
            }

            // Guardar en SQL Server
            _context.Tickets.Add(ticket);

            await _context.SaveChangesAsync();

            TempData["Mensaje"] = "¡Ticket registrado correctamente!";

            return RedirectToAction(nameof(MisTickets));
        }


        // Mostrar tickets registrados
        public async Task<IActionResult> MisTickets()
        {
            var tickets = await _context.Tickets
                .AsNoTracking()
                .Include(t => t.Categoria)
                .Include(t => t.Estado)
                .OrderByDescending(t => t.FechaCreacion)
                .ToListAsync();

            return View(tickets);
        }

        // Cargar categorías en el formulario
        private async Task CargarCategorias()
        {
            var categorias = await _context.Categorias
                .AsNoTracking()
                .ToListAsync();

            ViewBag.Categorias = new SelectList(
                categorias,
                "IdCategoria",
                "Nombre"
            );
        }
    }
}
