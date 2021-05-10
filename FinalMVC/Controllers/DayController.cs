using Final.Models.DayModels;
using Final.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalMVC.Controllers
{
    [Authorize]   //"One very nice attribute in C# is the  annotation. This annotation makes it so that the views are accessible only to logged in users:"
    public class DayController : Controller //"The [Day]Controller will manage views for Creating, Reading, Updating, and Deleting [Days]..."
    {
        // GET: Day
        public ActionResult Index()
        {
            //var model = new DayListItem[0];
            //return View();                         ----------------------In EN6.02, we changed these two lines to those below:
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DayService(userId);

            var model = service.GetAllDays();

            return View(model);
        }

        //"In the code above, we are initializing a new instance of the [Day]ListItem as an IEnumerable with the [0] syntax.  This will satisfy some of the requirements for our Index View.  When we added the List template for our view, it created some IEnumerable requirements for our list view.  More on that later." (EN. 4.04)

        //GET   --"We are making a request to get the Create View."  Without a view and a model for the view, the app will crash at this point.
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DayCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateDayService();

            if (service.CreateDay(model))
            {
                TempData["SaveResult"] = "Your Day was created!";  //tempdata removes info after it's accessed (EN7.02)
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Day could not be created.");

            return View(model);
        }

        private DayService CreateDayService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DayService(userId);
            return service;
        }
    }
}