using Microsoft.AspNetCore.Mvc;
using CalculatorApp.Models;
using System.Collections.Generic;

namespace CalculatorApp.Controllers
{
    public class HistoryController : Controller
    {
        public IActionResult Index()
        {
            List<Calculator> model = History.allCalculations;

            return View(model);
        }
    }
}
