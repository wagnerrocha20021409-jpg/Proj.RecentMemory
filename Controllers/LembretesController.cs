using Microsoft.AspNetCore.Mvc;
using RecentMemory.Contexts;
using RecentMemory.Models;

namespace RecentMemory.Controllers
{
    [Route("[Controller]")]
    public class LembretesController : Controller
    {
        RecentMemoryContext context = new RecentMemoryContext();
     
        public IActionResult Index()
        {
            var listaLembretes = context.Lugares.ToList();

            ViewBag.listaLembretes = listaLembretes;

            return View();
        }


         [Route("AdicionarLembrete/{idLembrete}")]
        public IActionResult Adicionar(int idLembrete)
        {
            Lembrete lembrete  = context.Lembretes.FirstOrDefault(x => x.Id == idLembrete);

            ViewBag.Lembrete = lembrete;

            return View();
        }
        [Route("AdicionarLembrete")]
        public IActionResult AdicionarLembrete(Lembrete Lembrete)
        {
            // Procurando os dados do usuario
            var usuario = context.Usuarios.FirstOrDefault(x => x.Email == HttpContext.Session.GetString("Usuario"));
            Lembrete.UsuarioId = usuario.Id;

            context.Add(Lembrete);

            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}