using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using duggaDotNet.Models;

namespace duggaDotNet.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            AliensModel sm = new AliensModel();
            ViewBag.AlienTable = sm.GetAllAliens();
            return View();
        }
    }
}