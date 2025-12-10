using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Proj.RecentMemory.Controllers
{
 public class ConfiguracoesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}