using CalculatorApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CalculatorApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index(Calculator calculator)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate (Calculator calculator)
        {
            if (calculator.RightOperand == 0 && calculator.Operator == "/")
            {
                TempData["error"] = "Cannot divide by zero!";
            }
            else
            {
                calculator.CalculateResult();
                calculator.TimeOfCalculation = DateTime.Now;
                History.allCalculations.Add(calculator);
            }
            return RedirectToAction("Index", calculator);
        }
    }
}
