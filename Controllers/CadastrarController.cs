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

            
        }
    }
}

            
            