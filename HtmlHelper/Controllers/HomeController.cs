using System.Diagnostics;
using FirstApp.Models;
using Microsoft.AspNetCore.Mvc;


namespace FirstApp.Controllers
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
            var students = new List<Student>
            {
                new Student { Id = 101, Name = "xyz", Age =34 , Salery = 50000},
                new Student { Id = 102, Name = "xyz", Age = 24 , Salery = 150000},
                new Student { Id = 103, Name = "xyz", Age = 23 , Salery = 250000},
                new Student { Id = 104, Name = "xyz", Age = 32 , Salery = 350000},
            };
            return View(students);
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
