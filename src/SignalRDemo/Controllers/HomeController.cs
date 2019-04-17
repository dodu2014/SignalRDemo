using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using SignalRDemo.Hubs;
using SignalRDemo.Models;
using SignalRDemo.Services;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SignalRDemo.Controllers
{
    public class HomeController : Controller
    {

        private readonly IHubContext<TestHub> hubContext;

        public HomeController(IHubContext<TestHub> hubContext) {
            this.hubContext = hubContext;
        }

        public IActionResult Index() {
            return View();
        }

        [ActionName("Test")]
        public async Task<IActionResult> TestAsync(string mode = "controller") {
            switch (mode.ToLower()) {
                case "controller":
                    await hubContext.Clients.All.SendAsync("OnResponse", new { desc = "from controller" });
                    break;
                case "service":
                    var _hc = ServicesContext.Provider.GetRequiredService<IHubContext<TestHub>>();
                    await _hc.Clients.All.SendAsync("OnResponse", new { desc = "from ServicesContext.Provider" });
                    break;
                default:
                    break;
            }
            return Content(mode);
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
