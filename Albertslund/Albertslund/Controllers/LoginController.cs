using Albertslund.Models;
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
        public ActionResult Index()
        {
            ViewModel view = new ViewModel();
            view.user = new User();
            view.userAddress = new UserAddress();
            view.userContact = new UserContact();
            view.userHouse = new UserHouse();
            return View(view);
        }
        [HttpPost]
        public ActionResult Login(ViewModel model)
        {
            DbContext context = HttpContext.RequestServices.GetService(typeof(Albertslund.Models.DbContext)) as DbContext;
            Debug.WriteLine(model.user.username);

            if (!context.GetUserByUsernameAndPassword(model.user.username, model.user.password))
            {
               if(context.createDBEntries())
                {
                    Debug.WriteLine("Wrote to DB");
                }
                Debug.WriteLine("Operation FAILED");
                return RedirectToAction("DbOperationError");
            }
            return RedirectToAction("Index");

        }
        public ActionResult DbOperationError()
        {
            return View();
        }

    }


}
