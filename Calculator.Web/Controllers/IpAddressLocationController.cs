using Calculator.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Calculator.Web.Controllers
{
    public class IpAddressLocationController : Controller
    {
        private readonly string _apiKey = "6327f0f0154148ccafb99665919dbd66"; // Replace with your actual API key

        public async Task<IActionResult> Index(string ipAddress)
        {
            var viewModel = new IpAddressLocationViewModel { IpAddress = ipAddress };
            if (!string.IsNullOrEmpty(ipAddress))
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetStringAsync($"https://api.ipgeolocation.io/ipgeo?apiKey={_apiKey}&ip={ipAddress}");
                    var locationData = JsonConvert.DeserializeObject<dynamic>(response);

                    viewModel.Country = locationData.country_name;
                    viewModel.City = locationData.city;
                    viewModel.Region = locationData.state_prov;
                    viewModel.Latitude = locationData.latitude;
                    viewModel.Longitude = locationData.longitude;
                }
            }
            return View(viewModel);
        }
    }
}
