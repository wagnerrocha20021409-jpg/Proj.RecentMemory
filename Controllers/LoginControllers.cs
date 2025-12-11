
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecentMemory.Contexts;
// using RecentMemory.Models; // caso tenha entidade Usuario
using System.Linq;

namespace RecentMemory.Controllers
{
    public class LoginController : Controller
    {
        RecentMemoryContext context = new RecentMemoryContext();

        public IActionResult Index()
        {
            return View();
        }

        // POST /Login (Processa credenciais)
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // Validação básica de entrada
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                ViewBag.Erro = "Email e senha são obrigatórios.";
                return View("Index");
            }

            // Buscar usuário por email
            var usuario = context.Usuarios.FirstOrDefault(u => u.Email == email);

            // Se não encontrou ou senha inválida (exemplo simples, sem hash)
            if (usuario == null || usuario.Senha != password)
            {
                ViewBag.Erro = "Email ou senha inválidos.";

                return View("Index");
            }
           
            HttpContext.Session.SetString("Usuario", usuario.Email);
            HttpContext.Session.SetString("NomeUsuario", usuario.Nome);

            return RedirectToAction("Index", "Home");
        }
    }
}
