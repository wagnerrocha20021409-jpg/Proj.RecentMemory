using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Proj.RecentMemory.Views.Home
{
    public class Lembretes : PageModel
    {
        private readonly ILogger<Lembretes> _logger;

        public Lembretes(ILogger<Lembretes> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}