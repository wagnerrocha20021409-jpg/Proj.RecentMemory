using Microsoft.AspNetCore.Mvc;
using RecentMemory.Contexts;

namespace RecentMemory.Controllers
{
    [Route ("[Controller]")]
    public class LugaresController : Controller
    {
        RecentMemoryContext context = new RecentMemoryContext();
        public IActionResult Index()
        {
            var listaLugares = context.Lugares.ToList();

            ViewBag.lisatLugares = listaLugares;

            return View();
        }

    }
}