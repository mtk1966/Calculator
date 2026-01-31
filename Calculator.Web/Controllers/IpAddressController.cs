using Calculator.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Web.Controllers
{
    public class IpAddressController : Controller
    {
        private readonly CalculatorDbContext _context;

        public IpAddressController(CalculatorDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var usersIpAddresses = await _context.UsersIpAdress.ToListAsync();
            return View(usersIpAddresses);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                var allIps = await _context.UsersIpAdress.ToListAsync();
                return PartialView("_IpAddressList", allIps);
            }

            if (int.TryParse(id, out int ipId))
            {
                var ipAddress = await _context.UsersIpAdress.Where(i => i.Id == ipId).ToListAsync();
                return PartialView("_IpAddressList", ipAddress);
            }

            return PartialView("_IpAddressList", new List<Calculator.Common.Models.UsersIpAddress>());
        }
    }
}

