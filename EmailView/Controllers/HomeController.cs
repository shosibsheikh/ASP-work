using EmailView.Models;
using System;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace emailPassWord.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new EmailViewModel()); // return empty form
        }

        [HttpPost]
        public ActionResult Index(EmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    mail.To.Add(model.To);
                    mail.From = new MailAddress("shoaibshobi3007@gmail.com");
                    mail.Subject = model.Subject;
                    mail.Body = model.Body;
                    mail.IsBodyHtml = true;

                    SmtpClient smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        Credentials = new NetworkCredential("shoaibshobi3007@gmail.com", "socv gwaa kvjs bact"),
                        EnableSsl = true
                    };

                    smtp.Send(mail);
                    ViewBag.Message = "✅ Mail Sent Successfully!";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "❌ Error: " + ex.Message;
                }
            }

            return View(model);
        }
    }
}
