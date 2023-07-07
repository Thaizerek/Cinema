using Cinema.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index(string name)
        {
            ViewData["name"] = name ?? "nieznajomy";
            return View();
        }
        [HttpPost]
        [ActionName("Index")]
        public IActionResult IndexPost(string name)
        {
            ViewData["name"] = (name ?? "nieznajomy").ToUpper();
            return View();
        }

        

        
    }
}
