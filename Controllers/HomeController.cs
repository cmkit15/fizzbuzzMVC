using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using fizzbuzzMVC.Models;
using System.Text;

namespace fizzbuzzMVC.Controllers
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

        [HttpGet]
        public IActionResult Solve()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Solve(int num1, int num2)
        {
            var startNum = Convert.ToInt32(num1);
            var endNum = Convert.ToInt32(num2);
                     
            //Step2 : Do something
            var output = new StringBuilder();
            for (var index = 1; index <= 100; index++)
            {
                if (index % startNum == 0 && index % endNum == 0)
                {
                    output.AppendLine("FIZZBUZZ");
                } else if (index % startNum == 0)
                {
                    output.AppendLine("FIZZ");
                } else if (index % endNum == 0)
                {
                    output.AppendLine("BUZZ");
                } else
                {
                    output.AppendLine($"{index}");
                }  
            }

            ViewData["numbers"] = $"Your numbers are {startNum} and {endNum}";
            ViewData["Output"] = output.ToString();

            return View();
        }

        public IActionResult Code()
        {
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
