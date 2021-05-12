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
    public class AccountInformationController : Controller
    {

        public ActionResult Index()
        {

            if (HttpContext.Session.GetInt32("SessionUserId") == null)
            {

                return Redirect("Home/Index");
            }
            else
            {

                DbContext context = HttpContext.RequestServices.GetService(typeof(Albertslund.Models.DbContext)) as DbContext;

                ViewModel mymodel = new ViewModel();
                mymodel.user = context.GetUser((int)HttpContext.Session.GetInt32("SessionUserId"));

                mymodel.userAddress = context.GetUserAddress(mymodel.user.address_id);
                mymodel.userContact = context.GetUserContact(mymodel.user.contact_id);
                mymodel.userHouse = context.GetUserHouse(mymodel.user.house_id);
                return View(mymodel);
            }
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
        
        public ActionResult DbOperationError()
        {
            
            return View();
        }

    }
}
