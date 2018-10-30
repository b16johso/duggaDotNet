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
        private AliensModel sm = new AliensModel();

        public IActionResult Index()
        {
            ViewBag.AlienTable = sm.GetAllAliens();
            ViewBag.RaceTable = sm.GetAllRaces();
            ViewBag.DemographyTable = sm.GetAlienDemography();
            return View();
        }
        public IActionResult SearchAliens(string name)
        {
            ViewBag.SearchResults = sm.SearchAliens(name);
            return View();
        }

        public IActionResult ClassifyRace(string race)
        {
            sm.ClassifyRace(race);
            return RedirectToAction("Index");
        }

        public IActionResult InsertAlien(string IDkod, string namn, int farlighet, string rasNamn)
        {
            sm.InsertAlien(IDkod, namn, farlighet, rasNamn);
            return RedirectToAction("Index");
        }
    }
}