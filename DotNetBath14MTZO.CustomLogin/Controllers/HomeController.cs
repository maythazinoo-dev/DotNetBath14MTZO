using DotNetBath14MTZO.CustomLogin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace DotNetBath14MTZO.CustomLogin.Controllers
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
            // Check if the user is authenticated by verifying the session
            var email = HttpContext.Session.GetString("email");
            if (string.IsNullOrEmpty(email))
            {
                // If not authenticated, redirect to the login page
                return RedirectToAction("Index", "SignIn");
            }

            return View();
        }


        public IActionResult Privacy()
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
