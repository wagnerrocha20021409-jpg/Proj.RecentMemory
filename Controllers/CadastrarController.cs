using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RecentMemory.Contexts;
using RecentMemory.Models;
 
namespace RecentMemory.Controllers
{
    public class CadastrarController : Controller
    {
        RecentMemoryContext context = new RecentMemoryContext();
 
        public IActionResult Index()
        {
            return View();
        }
 
        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar(string nome, string email, string password, string confirmPassword)
        {
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.ErroRegistro = "Todos os campos são obrigatórios";
                return View("Login");
            }
 
             if (password != confirmPassword)
            {
                ViewBag.ErroRegistro = "As senhas não conferem";
                return RedirectToAction("Index");
            }
 
            if (password.Length < 8)
            {
                ViewBag.ErroRegistro = "A senha deve ter pelo menos 8 caracteres";
                return RedirectToAction("Index");
            }
 
            if (context.Usuarios.Any(u => u.Email == email))
            {
                ViewBag.ErroRegistro = "Este email já está cadastrado";
                return RedirectToAction("Index");
            }
 
            var novoUsuario = new Usuario
            {
                Nome = nome,
                Email = email,
                Senha = password
            };
 
            context.Usuarios.Add(novoUsuario);
 
            context.SaveChanges();
 
            return RedirectToAction("Index", "Home");
        }
    }
}
 
           
           
 