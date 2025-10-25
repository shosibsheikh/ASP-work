using Microsoft.AspNetCore.Mvc;

namespace HtmlHelper.Controllers
{
    public class HTMLhelperController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
