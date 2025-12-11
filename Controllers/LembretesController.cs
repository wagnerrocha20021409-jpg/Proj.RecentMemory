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

        [HttpDelete("Remover/{id}")]
        public IActionResult Remover(int id)
        {
            // Procurando lugares que contenham
            var listaLugaresLembretes = context.LugaresLembretes.Where(x => x.LembretesId == id).ToList();

            if (listaLugaresLembretes != null && listaLugaresLembretes.Count > 0)
            {
                foreach (var lg in listaLugaresLembretes)
                {
                    context.Remove(lg);
                }

                context.SaveChanges();
            }

            // Procurando contatos que contenham
            var listaContatosLembretes = context.ContatosLembretes.Where(x => x.LembretesId == id).ToList();

            if (listaContatosLembretes != null && listaContatosLembretes.Count > 0)
            {
                foreach (var ct in listaContatosLembretes)
                {
                    context.Remove(ct);
                }

                context.SaveChanges();
            }

            Lembrete lembrete = context.Lembretes.FirstOrDefault(l => l.Id == id);

            context.Remove(lembrete);

            context.SaveChanges();

            return RedirectToAction("Index", "Lembretes");

        }
        
          
            [HttpPut("Editar")]
            public IActionResult Editar([FromBody] Lembrete lembreteAtualizado)
            {
                var lembreteDb = context.Lembretes.FirstOrDefault(l => l.Id == lembreteAtualizado.Id);
                if (lembreteDb == null)
                {

                    return NotFound();

                }

                lembreteDb.Titulo = lembreteAtualizado.Titulo;
                lembreteDb.Descricao = lembreteAtualizado.Descricao;
                // lembreteDb.Data = lembreteAtualizado.Data;
                lembreteDb.Prioridade = lembreteAtualizado.Prioridade;
                // lembreteDb.Concluido = lembreteAtualizado.Concluido;
                
              

                context.SaveChanges();

                return Ok(new { message = "Lembrete atualizado com sucesso!" });
            }


    }
}