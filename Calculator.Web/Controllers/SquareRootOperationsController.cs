using Calculator.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Calculator.Web.Controllers
{
    //[Authorize]
    public class SquareRootOperationsController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Simplify()
        {
            return View(new SquareRootViewModel());
        }

        [HttpPost]
        public IActionResult Simplify(SquareRootViewModel model)
        {
            var (newCoeff, newRad) = GetSimplifiedParts(model.A1, model.B1);
            model.Result = FormatSquareRoot(newCoeff, newRad);
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new SquareRootViewModel());
        }

        [HttpPost]
        public IActionResult Add(SquareRootViewModel model)
        {
            if (model.B1 < 0 || model.B2 < 0)
            {
                model.Result = "Karekök içi negatif olamaz.";
                return View(model);
            }

            var (newA1, newB1) = GetSimplifiedParts(model.A1, model.B1);
            var (newA2, newB2) = GetSimplifiedParts(model.A2, model.B2);

            if (newB1 == newB2)
            {
                double finalA = newA1 + newA2;
                model.Result = FormatSquareRoot(finalA, newB1);
            }
            else
            {
                model.Result = "Kökler farklı olduğu için toplama yapılamaz.";
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Subtract()
        {
            return View(new SquareRootViewModel());
        }

        [HttpPost]
        public IActionResult Subtract(SquareRootViewModel model)
        {
            if (model.B1 < 0 || model.B2 < 0)
            {
                model.Result = "Karekök içi negatif olamaz.";
                return View(model);
            }

            var (newA1, newB1) = GetSimplifiedParts(model.A1, model.B1);
            var (newA2, newB2) = GetSimplifiedParts(model.A2, model.B2);

            if (newB1 == newB2)
            {
                double finalA = newA1 - newA2;
                model.Result = FormatSquareRoot(finalA, newB1);
            }
            else
            {
                model.Result = "Kökler farklı olduğu için çıkarma yapılamaz.";
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Multiply()
        {
            return View(new SquareRootViewModel());
        }

        [HttpPost]
        public IActionResult Multiply(SquareRootViewModel model)
        {
            if (model.B1 < 0 || model.B2 < 0)
            {
                model.Result = "Karekök içi negatif olamaz.";
            }
            else
            {
                double newA = model.A1 * model.A2;
                long newB = model.B1 * model.B2;
                var (finalA, finalB) = GetSimplifiedParts(newA, newB);
                model.Result = FormatSquareRoot(finalA, finalB);
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Divide()
        {
            return View(new SquareRootViewModel());
        }

        [HttpPost]
        public IActionResult Divide(SquareRootViewModel model)
        {
            if (model.B1 < 0 || model.B2 < 0)
            {
                model.Result = "Karekök içi negatif olamaz.";
            }
            else if (model.A2 == 0 || model.B2 == 0)
            {
                model.Result = "Sıfıra bölme hatası.";
            }
            else
            {
                double coefficient = (double)model.A1 / (model.A2 * model.B2);
                long radicand = model.B1 * model.B2;
                var (finalA, finalB) = GetSimplifiedParts(coefficient, radicand);
                model.Result = FormatSquareRoot(finalA, finalB);
            }
            return View(model);
        }

        private (double, long) GetSimplifiedParts(double coefficient, long radicand)
        {
            if (radicand < 0) return (double.NaN, -1); 

            long number = radicand;
            long a = 1;
            long b = number;

            for (long i = (long)Math.Sqrt(number); i >= 2; i--)
            {
                if (number % (i * i) == 0)
                {
                    a = i;
                    b = number / (i * i);
                    break;
                }
            }
            
            coefficient *= a;
            return (coefficient, b);
        }

        private string FormatSquareRoot(double coefficient, long radicand)
        {
            if (radicand == 1)
            {
                return $"{coefficient}";
            }
            else
            {
                return $"{coefficient}√{radicand}";
            }
        }
    }
}