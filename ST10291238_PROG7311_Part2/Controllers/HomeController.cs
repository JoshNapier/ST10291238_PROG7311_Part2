using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ST10291238_PROG7311_Part2.Models;

namespace ST10291238_PROG7311_Part2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult AddProducts()
        {
            return View();
        }

        public IActionResult MyProducts()
        {
            return View();
        }

        public IActionResult AllProducts()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
