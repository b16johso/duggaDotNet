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
            CustomersModel sm = new CustomersModel();
            ViewBag.CustomerTable = sm.GetAllCustomers();
            return View();
        }
    }
}