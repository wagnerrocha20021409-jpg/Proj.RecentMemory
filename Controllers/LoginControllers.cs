
using Microsoft.AspNetCore.Mvc;
using RecentMemory.Models;
using RecentMemory.Contexts;

namespace RecentMemory.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        [Route("Login")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Login")]
        public IActionResult Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.Erro = "Email e senha são obrigatórios";
                return View();
            }

            // Validação simples (implementar com banco de dados real)
            if (email == "test@example.com" && password == "123456")
            {
                HttpContext.Session.SetString("Usuario", email);
                HttpContext.Session.SetString("NomeUsuario", "João Silva");
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Erro = "Email ou senha inválidos";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("auth/register")]
        public IActionResult Register(string nome, string email, string password, string confirmPassword)
        {
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.ErroRegistro = "Todos os campos são obrigatórios";
                return View("Login");
            }

            if (password != confirmPassword)
            {
                ViewBag.ErroRegistro = "As senhas não conferem";
                return View("Login");
            }

            HttpContext.Session.SetString("Usuario", email);
            HttpContext.Session.SetString("NomeUsuario", nome);
            
            ViewBag.SucessoRegistro = "Cadastro realizado com sucesso! Você será redirecionado em 2 segundos...";
            return View("Login");
        }

        [HttpGet]
        [Route("auth/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
