using Calculator.Common.Models;
using Calculator.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace Calculator.Web.Controllers
{
    [Authorize]
    public class ProcessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Collection()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Collection(ProcessViewModel model)
        {
            double equals;
            if (!model.Number3.HasValue)
            {
                equals = model.Number1 + model.Number2;
            }
            else
            {
                equals = model.Number1 + model.Number2 + model.Number3.Value;
            }
            ViewBag.Result = equals;
            return View(model);
        }
        public IActionResult Extraction()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Extraction(ProcessViewModel model)
        {
            double equals;
            if (!model.Number3.HasValue)
            {
                equals = model.Number1 - model.Number2;
            }
            else
            {
                equals = model.Number1 - model.Number2 - model.Number3.Value;
            }
            ViewBag.Result = equals;
            return View(model);
        }
        public IActionResult Multiplication()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Multiplication(ProcessViewModel model)
        {
            double equals;
            if (!model.Number3.HasValue)
            {
                equals = model.Number1 * model.Number2;
            }
            else
            {
                equals = model.Number1 * model.Number2 * model.Number3.Value;
            }
            ViewBag.Result = equals;
            return View(model);
        }
        public IActionResult Compartment()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Compartment(ProcessViewModel model)
        {
            if (model.Number2 == 0 || (model.Number3.HasValue && model.Number3.Value == 0))
            {
                ModelState.AddModelError(string.Empty, "Sıfıra bölme hatası.");
            }
            else
            {
                double equals;
                if (!model.Number3.HasValue)
                {
                    equals = model.Number1 / model.Number2;
                }
                else
                {
                    equals = model.Number1 / model.Number2 / model.Number3.Value;
                }
                ViewBag.Result = equals;
            }
            return View(model);
        }
    }
}
