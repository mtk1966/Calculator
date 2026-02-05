using Calculator.Data;
using Calculator.Common;
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
            string userIpAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            var usagePeriod = _context.UsagePeriod.FirstOrDefault();
            ViewBag.TotalOperations = usagePeriod?.Usageperiod ?? 0;
            if (!_context.UsersIpAdress.Any(x => x.IpAdress == userIpAddress))
            {
                var newUserIp = new Calculator.Common.Models.UsersIpAddress
                {
                    IpAdress = userIpAddress,
                    AddDate = DateTime.Now
                };
                _context.UsersIpAdress.Add(newUserIp);
                _context.SaveChanges();
                ViewBag.ShowModal = true; // Show modal for new users
            }
            else
            {
                ViewBag.ShowModal = false; // Do not show modal for returning users
            }
            return View();
        }
        public IActionResult AboutMe()
        {
            return View();
        }


    }
}