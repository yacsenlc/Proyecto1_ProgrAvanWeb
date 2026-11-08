
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Help_Desk.Data;
using System.Threading.Tasks;

namespace Proyecto_Help_Desk.Controllers
{
    public class PruebaController : Controller
    {
        private readonly HelpDeskContext _context;

        public PruebaController(HelpDeskContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var categorias = await _context.Categorias
                .AsNoTracking()
                .ToListAsync();

            return Json(new
            {
                mensaje = "Conexion exitosa con SQL Server",
                cantidadCategorias = categorias.Count,
                categorias = categorias
            });
        }
    }
}
