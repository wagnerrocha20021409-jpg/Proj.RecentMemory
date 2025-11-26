using Microsoft.AspNetCore.Mvc;
using RecentMemory.Contexts;

namespace RecentMemory.Controllers
{
    [Route ("[Controller]")]
    public class ContatosControler : Controller
    {
        RecentMemoryContext context = new RecentMemoryContext();
        public IActionResult index()
        {
            var listaContatos = context.Contatos.ToList();

            ViewBag.listaContatos = listaContatos;

            return View();
        }

    }
}