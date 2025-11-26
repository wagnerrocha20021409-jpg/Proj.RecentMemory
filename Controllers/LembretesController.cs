using Microsoft.AspNetCore.Mvc;
using RecentMemory.Contexts;

namespace RecentMemory.Controllers
{
<<<<<<< HEAD
    [Route ("[Controller]")]
=======
    [Route("[controller]")]
>>>>>>> 078179d9f6957ff6cf44f7514d46b5eb842fa747
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