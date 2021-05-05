using Albertslund.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Albertslund.Controllers
{
    public class AccountInformationController : Controller
    {

        public ActionResult Index()
        {
            DbContext context = HttpContext.RequestServices.GetService(typeof(Albertslund.Models.DbContext)) as DbContext;
            
            ViewModel mymodel = new ViewModel();
            mymodel.user = context.GetUser(1);
   
            mymodel.userAddress = context.GetUserAddress(1);
            mymodel.userContact = context.GetUserContact(1);
            mymodel.userHouse = context.GetUserHouse(1);
            return View(mymodel);
        }

        [HttpPost]
        public ActionResult UpdatePassword(ViewModel mymodel)
        {
  
      
            DbContext context = HttpContext.RequestServices.GetService(typeof(Albertslund.Models.DbContext)) as DbContext;

           if (!context.UpdateUser(mymodel.user.user_id, mymodel.user.password))
            {
                return RedirectToAction("DbOperationError");
            }
            return RedirectToAction("Index");


        }

        public ActionResult UpdateContact(ViewModel mymodel)
        {


            DbContext context = HttpContext.RequestServices.GetService(typeof(Albertslund.Models.DbContext)) as DbContext;

            if (!context.UpdateContact(mymodel.userContact))
            {
                return RedirectToAction("DbOperationError");
            }
            return RedirectToAction("Index");


        }
        public ActionResult UpdateHouse(ViewModel mymodel)
        {


            DbContext context = HttpContext.RequestServices.GetService(typeof(Albertslund.Models.DbContext)) as DbContext;

            if (!context.UpdateHouse(mymodel.userHouse))
            {
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
