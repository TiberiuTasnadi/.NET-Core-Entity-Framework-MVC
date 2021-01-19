using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using coreMVC.Models;
using DataAccess;
using DataAccess.Models;

namespace coreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            using (var db = new MechanicContext())
            {
                //db.Add(new Car { id = 1, model = "test1", numWeels = 4 });

                bool hasCars = db.Cars.Any();
                if (!hasCars)
                {
                    db.Add(new Car { id = 1, model = "test1", numWeels = 4 });
                    db.Add(new Car { id = 2, model = "test2", numWeels = 4 });
                    db.Add(new Car { id = 3, model = "test3", numWeels = 4 });
                    db.Add(new Car { id = 4, model = "test4", numWeels = 4 });
                    db.SaveChanges();
                }                             
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
