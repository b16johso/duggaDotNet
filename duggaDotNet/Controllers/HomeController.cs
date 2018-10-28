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
        private AliensModel sp = new AliensModel();

        public IActionResult Index()
        {
            AliensModel sm = new AliensModel();
            ViewBag.AlienTable = sm.GetAllAliens();
            ViewBag.RaceTable = sm.GetAllRaces();
            ViewBag.DemographyTable = sm.GetAlienDemography();
            return View();
        }
        public IActionResult SearchAliens(string name)
        {
            ViewBag.SearchResults = sp.SearchAliens(name);
            return View();
        }
    }
}