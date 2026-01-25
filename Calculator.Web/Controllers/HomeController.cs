using Calculator.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Calculator.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly CalculatorDbContext _context;

        public HomeController(CalculatorDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var usagePeriod = _context.UsagePeriod.FirstOrDefault();
            ViewBag.TotalOperations = usagePeriod?.Usageperiod ?? 0;
            return View();
        }
        public IActionResult AboutMe()
        {
            return View();
        }

    }
}