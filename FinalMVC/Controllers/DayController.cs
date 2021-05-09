using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalMVC.Controllers
{
    public class DayController : Controller //"The [Day]Controller will manage views for Creating, Reading, Updating, and Deleting [Days]..."
    {
        // GET: Day
        public ActionResult Index()
        {
            return View();
        }
    }
}