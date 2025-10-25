using System.Diagnostics;
using EmailDBlogin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace EmailDBlogin.Controllers
{
    public class HomeController : Controller
    {
        private readonly LoginContext context;

        public HomeController(LoginContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserTbl user)
        {
            var myUser = context.UserTbls.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();

            if (myUser != null)
            {
                HttpContext.Session.SetString("UserSession", myUser.Email);
                return RedirectToAction("DashBoard");
            }
            else
            {
                ViewBag.Message = "login falied";
            }
            return View();
        }
        public IActionResult DashBoard()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Index");
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




