using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using Albertslund.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Albertslund.Controllers
{
    public class ContactAdvisorController : Controller
    {
        //not used
        /*
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("SessionUserId") == null)
            {
                
                return Redirect("Home/Index");
            }
            else
            {
                ViewBag.UserLogged = HttpContext.Session.GetInt32("SessionUserId");
                return View();
            }
                
        } */

        [HttpPost]
        public IActionResult SendEmail(ViewModel viewModel)
        {
            Debug.WriteLine(viewModel.email.from);
            MailMessage message = new MailMessage();
            message.To.Add("albertslund.project@gmail.com");
            message.From = new MailAddress(viewModel.email.from);
            message.Subject = viewModel.email.subject;
            message.Body = string.Format("Message send by: {0} {1} from {2}\n {3}", viewModel.email.firstName, viewModel.email.lastName, viewModel.email.from, viewModel.email.body);
            message.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;

            smtp.Credentials = new System.Net.NetworkCredential("albertslund.project@gmail.com", "Albertslund2021");
            smtp.Send(message);
            return RedirectToAction("Index","Home");
        }
    }
}
