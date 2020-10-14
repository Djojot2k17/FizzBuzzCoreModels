using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FizzBuzzCoreModels.Models;
using FizzBuzzCoreModels;

namespace FizzBuzzCoreModels.Controllers
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
            return View();
        }

        public IActionResult Code()
        {
            return View();
        }
        public IActionResult Solve()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Solve(int fizzNum1, int fizzNum2)
        {
            var fizzModel = new FizzBuzz {
                FizzNum = fizzNum1,
                BuzzNum = fizzNum2
            };
            
            // Start fizzbuzz
            ViewData["FizzBuzz"] = "";
            for (var i = 1; i <= 100; i++)
            {
                if (i % fizzNum1 == 0 && i % fizzNum2 == 0)
                {
                    // fizz buzz
                    fizzModel.Output += " FizzBuzz! -";
                }
                else if (i % fizzNum1 == 0)
                {
                    // fizz
                    fizzModel.Output += " Fizz! -";
                }
                else if (i % fizzNum2 == 0)
                {
                    // buzz
                    fizzModel.Output += " Buzz! -";
                }
                else
                {
                    // i
                    fizzModel.Output += $" {i} -";
                }
            }
            return View("Result", fizzModel);
        }

        public IActionResult Result(FizzBuzz model)
        {
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
