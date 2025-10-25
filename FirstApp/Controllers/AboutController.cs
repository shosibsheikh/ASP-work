using FirstApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            Student students = new Student()
            {
                Id = 101,
                Name = "Ahmer",
                Age = 34,
                Salery =  1000000  ,  
            };
            return View(students);
        } 
    }
}
