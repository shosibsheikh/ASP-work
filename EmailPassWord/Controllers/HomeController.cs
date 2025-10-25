using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;



namespace emailPassWord.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        //noorunnisa560 @gmail.com
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {

            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add("shoaibshobi3007@gmail.com");
                mail.From = new MailAddress("shoaibshobi3007@gmail.com");
                mail.Subject = "Test Email from ASP.NET MVC";
                mail.Body = "Hello! This is a test email sent from ASP.NET MVC app.";
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";  // Gmail SMTP
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential("shoaibshobi3007@gmail.com", "mbuc ayli gduf ealc");
                smtp.EnableSsl = true;

                smtp.Send(mail);
                ViewBag.Message = "Mail Sent Successfully!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: " + ex.Message;
            }

            return View();
        }
       
    }
}