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
            // Lista de lugares 
            var listaLugares = context.Lugares.ToList();
            ViewBag.ListaLugares = listaLugares;

            // Lista de contatos
            var listaContatos = context.Contatos.ToList();
            ViewBag.ListaContatos = listaContatos;

            var listaLembretes = context.Lembretes.ToList();

            ViewBag.listaLembretes = listaLembretes;

            return View();
        }


        // [Route("AdicionarLembrete/{idLembrete}")]
        // public IActionResult Adicionar(int idLembrete)
        // {
        //     Lembrete lembrete  = context.Lembretes.FirstOrDefault(x => x.Id == idLembrete);

        //     ViewBag.Lembrete = lembrete;

        //     return View();
        // }

        [HttpPost]
        public IActionResult AdicionarLembrete(Lembrete Lembrete, string[] contatos, string[] lugares)
        {
            // Procurando os dados do usuario
            var usuario = context.Usuarios.FirstOrDefault(x => x.Email == HttpContext.Session.GetString("Usuario"));

            Lembrete.UsuarioId = usuario.Id;

            // Inserindo Lembrete
            context.Add(Lembrete);

            context.SaveChanges();

            // Vinculo com contatos
            if (contatos != null)
            {
                foreach (var ct in contatos)
                {
                    context.ContatosLembretes.Add(new ContatoLembrete
                    {
                        LembretesId = Lembrete.Id,
                        ContatosId = int.Parse(ct)
                    });
                }
            }

            // Vinculo com lugares
            if (lugares != null)
            {
                foreach (var lg in lugares)
                {
                    context.LugaresLembretes.Add(new LugaresLembrete
                    {
                        LembretesId = Lembrete.Id,
                        LugaresId = int.Parse(lg)
                    });
                }
            }

            // Salva tudo de uma vez
            context.SaveChanges();

             return RedirectToAction("Index");
        }
    }
} 