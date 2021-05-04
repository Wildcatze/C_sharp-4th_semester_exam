using Albertslund.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Albertslund.Controllers
{
    public class AccountInformationController : Controller
    {
        public IActionResult Index()
        {
            DbContext context = HttpContext.RequestServices.GetService(typeof(Albertslund.Models.DbContext)) as DbContext;

            ViewModel mymodel = new ViewModel();
            mymodel.user = context.GetUser(1);
            mymodel.userAddress = context.GetUserAddress(1);
            mymodel.userContact = context.GetUserContact(1);
            mymodel.userHouse = context.GetUserHouse(1);
            return View(mymodel);
        }
    }
}
