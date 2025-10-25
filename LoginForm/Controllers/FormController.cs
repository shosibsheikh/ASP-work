using Microsoft.AspNetCore.Mvc;

namespace LoginForm.Controllers
{
    public class FormController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("user") != null)
            {
                ViewBag.sessionCheck = HttpContext.Session.GetString("user");
                return RedirectToAction("Wellcom");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(string usernamr, string password)
        {
            if (usernamr == "admin" && password == "abc")
            {
                HttpContext.Session.SetString("user", usernamr);
                HttpContext.Session.SetString("user", password);
                return RedirectToAction("Wellcom");
            }
            ViewBag.ErrorMessage = "Invalid username or password.";
            return View("Wellcom");
        }
        public IActionResult Wellcom()
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                ViewBag.user = HttpContext.Session.GetString("user");
                return View();

            }
            return RedirectToAction("Login");
        }
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return View("logout");
        }
    }
}
