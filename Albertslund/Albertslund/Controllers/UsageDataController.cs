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
    public class UsageDataController : Controller
    {

        public ActionResult Index()
        {
            if (HttpContext.Session.GetInt32("SessionUserId") != null)
            {
                 ViewBag.UserLogged = HttpContext.Session.GetInt32("SessionUserId");
                 return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
               
        }

        public ActionResult CSVDataDisplay()
        {
            DbContext context = HttpContext.RequestServices.GetService(typeof(Albertslund.Models.DbContext)) as DbContext;
            if (HttpContext.Session.GetInt32("SessionUserId") != null)
            {
                List<CSVData> csvDataArray = context.GetCSVData((int)HttpContext.Session.GetInt32("SessionUserId"));
                ViewBag.csvArray = csvDataArray;
                ViewBag.UserLogged = HttpContext.Session.GetInt32("SessionUserId");


                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

    }

}
