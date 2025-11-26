using Microsoft.AspNetCore.Mvc;
using RecentMemory.Contexts;

namespace RecentMemory.Controllers
{
    [Route("[controller]")]
    public class LembretesController : Controller
    {
        RecentMemoryContext context = new RecentMemoryContext();
        public IActionResult Index()
        {
            var listaLembretes = context.Lugares.ToList();

            ViewBag.listaLembretes = listaLembretes;

            return View();
        }

    }
}