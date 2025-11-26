using Microsoft.AspNetCore.Mvc;
using RecentMemory.Contexts;

namespace RecentMemory.Controllers
{
    [Route ("[Controller]")]
    public class LembretesController : Controller
    {
        RecentMemoryContext context = new RecentMemoryContext();
        public IActionResult index()
        {
            var listaLembretes = context.Lugares.ToList();

            ViewBag.listaLembretes = listaLembretes;

            return View();
        }

    }
}