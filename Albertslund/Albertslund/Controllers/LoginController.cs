using Albertslund.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Albertslund.Controllers
{
    public class LoginController : Controller
    {

        [HttpPost]
        public ActionResult Login(ViewModel model)
        {
            DbContext context = HttpContext.RequestServices.GetService(typeof(Albertslund.Models.DbContext)) as DbContext;
            Debug.WriteLine(model.user.username);
            User user = context.GetUserByUsernameAndPassword(model.user.username, model.user.password);
            if (user == null)
            {
               if(context.createDBEntries())
                {
                    Debug.WriteLine("Wrote to DB");
                }
                Debug.WriteLine("Operation FAILED");
                HttpContext.Session.SetInt32("SessioSuccess", 0);
                return RedirectToAction("Index", "Home");
                
            }

            HttpContext.Session.SetInt32("SessionUserId", user.user_id);
            HttpContext.Session.SetInt32("SessioSuccess", 1);


            return RedirectToAction("Index", "Home");

        }
        public ActionResult DbOperationError()
        {
            return View();
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}
