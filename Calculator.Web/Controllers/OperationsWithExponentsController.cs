using Calculator.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Web.Controllers
{
    public class OperationsWithExponentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new ExponentViewModel());
        }

        [HttpPost]
        public IActionResult Add(ExponentViewModel model)
        {
            if (model.Base1 == model.Base2 && model.Exponent1 == model.Exponent2)
            {
                double newCoefficient = model.Coefficient1 + model.Coefficient2;
                model.Result = $"{newCoefficient} * {model.Base1}^{model.Exponent1}";
            }
            else
            {
                model.Result = "Tabanlar ve üsler aynı olmadığından toplama yapılamaz.";
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Subtract()
        {
            return View(new ExponentViewModel());
        }

        [HttpPost]
        public IActionResult Subtract(ExponentViewModel model)
        {
            if (model.Base1 == model.Base2 && model.Exponent1 == model.Exponent2)
            {
                double newCoefficient = model.Coefficient1 - model.Coefficient2;
                model.Result = $"{newCoefficient} * {model.Base1}^{model.Exponent1}";
            }
            else
            {
                model.Result = "Tabanlar ve üsler aynı olmadığından çıkarma yapılamaz.";
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Multiply()
        {
            return View(new ExponentViewModel());
        }

        [HttpPost]
        public IActionResult Multiply(ExponentViewModel model)
        {
            double newCoefficient = model.Coefficient1 * model.Coefficient2;
            if (model.Base1 == model.Base2)
            {
                long newExponent = model.Exponent1 + model.Exponent2;
                model.Result = $"{newCoefficient} * {model.Base1}^{newExponent}";
            }
            else
            {
                model.Result = $"{newCoefficient} * ({model.Base1}^{model.Exponent1} * {model.Base2}^{model.Exponent2})";
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Divide()
        {
            return View(new ExponentViewModel());
        }

        [HttpPost]
        public IActionResult Divide(ExponentViewModel model)
        {
            if (model.Coefficient2 == 0)
            {
                model.Result = "Sıfıra bölme hatası.";
                return View(model);
            }

            double newCoefficient = model.Coefficient1 / model.Coefficient2;
            if (model.Base1 == model.Base2)
            {
                long newExponent = model.Exponent1 - model.Exponent2;
                model.Result = $"{newCoefficient} * {model.Base1}^{newExponent}";
            }
            else
            {
                model.Result = $"{newCoefficient} * ({model.Base1}^{model.Exponent1} / {model.Base2}^{model.Exponent2})";
            }
            return View(model);
        }
    }
}
