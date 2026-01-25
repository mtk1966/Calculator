using Calculator.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Calculator.Web.Controllers
{
    public class AreaAndPerimeterCalculationController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new ShapeViewModel());
        }

        [HttpPost]
        public IActionResult Index(ShapeViewModel model)
        {
            model.Area = null;
            model.Perimeter = null;

            switch (model.SelectedShape)
            {
                case ShapeType.Kare:
                    model.Area = model.SideA * model.SideA;
                    model.Perimeter = 4 * model.SideA;
                    break;
                case ShapeType.Dikdörtgen:
                    model.Area = model.SideA * model.SideB;
                    model.Perimeter = 2 * (model.SideA + model.SideB);
                    break;
                case ShapeType.Üçgen:
                    // Assuming SideA is the base
                    model.Area = (model.SideA * model.Height) / 2;
                    model.Perimeter = model.SideA + model.SideB + model.SideC;
                    break;
            }

            return View(model);
        }
    }
}