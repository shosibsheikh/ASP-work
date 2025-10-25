using System.Diagnostics;
using HtmlHelper.Models;
using Microsoft.AspNetCore.Mvc;

namespace HtmlHelper.Controllers
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
            ViewData["Data1"] = "ViewDat";
            ViewBag.Data2 = "ViewBag";
            TempData["Data3"] = "TempData";

            TempData["Data4"] = new List<string>()
            {
                "Cricket","Football","Hockey"
            };
            return View();
        }
        public int Edit(int Id)
        {
            return Id;
        }

        public IActionResult Vdata()
        {
            ViewData["Data1"] = "WelCOME";
            ViewData["Data2"] = 23;
            ViewData["Data3"] = DateTime.Now.ToLongDateString();

            string[] arr = { "Ali", "salman", "Haris" };
            ViewData["Data4"] = arr;

            ViewData["Data5"] = new List<string>()
            {
                "Cricket","Football","Hockey"
            };
            //VewBag calling in Index.cshtml from ViewData 
            ViewBag.myName = "VewBag calling in Index.cshtml from ViewData";
            return View();
        }
        public IActionResult Vbag()
        {
            ViewBag.Data1 = "WelCOME";
            ViewBag.Data2 = 23;
            ViewBag.Data3 = DateTime.Now.ToShortDateString();

            string[] arr = { "Ali", "salman", "Haris" };
            ViewBag.Data4 = arr;

            ViewBag.Data5 = new List<string>()
            {
                "Cricket","Football","Hockey"
            };
            //VewData calling in Index.cshtml from ViewBag 
            ViewData["myName"] = "VewData calling in Index.cshtml from ViewBag";

            return View();
        }
        public IActionResult Tdata()
        {
            //ViewData["Data1"] = "ViewDat";
            //ViewBag.Data2 = "ViewBag";
            //TempData["Data3"] = "TempData";

            TempData["Data4"] = null; 
           
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
