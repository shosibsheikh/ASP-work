using System.Diagnostics;
using CrudAppADO.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudAppADO.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployeesDataALaye dal;
        public HomeController()
        {
            dal = new EmployeesDataALaye();
        }
        
           public IActionResult Index()
        {
            List<Employees> emps = dal.GetAllEmployees();
            return View(emps);
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
