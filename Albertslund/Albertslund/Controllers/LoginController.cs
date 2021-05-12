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
                Debug.WriteLine("Operation FAILED");
                ViewBag.LoginMessage = "Wrong credentials, try to login again.";
                return RedirectToAction("Index","Home");
            }

            HttpContext.Session.SetInt32("SessionUserId", user.user_id);
          
           
            return RedirectToAction("Index","Home");

        }
        public ActionResult DbOperationError()
        {
            return View();
        }

    }


}
