using Final.Models;
using Final.Models.TaskModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalMVC.Controllers
{
    [Authorize]  //"One very nice attribute in C# is the Authorize annotation.  This annotation makes it so that the views are accessible only to logged-in users."
    public class ToDoController : Controller //"1. The first word in the controller name will be the first part of our path.  Keep that in mind.  Our path will be localhost:xxxxx/[Task]."
    {
        // GET: ToDo
        public ActionResult Index() //"2. The ActionResult is a return type.  You can read more in the docs later, but for now, realize that it allows us to return a View() method.  The View() method will return a view that corresponds to the [Task]Controller." "3. When running the app, we can go to localhost:xxxxx/[Task]/Index.  Notice the path starts with the name of the controller (without the word controller), then the name of the action, which is Index."
        {
            var model = new ToDoListItem[0];  //"...we are initializing a new instance of the [ToDo]ListItem as an IEnumerable with the [0] syntax.  This will satisfy some of the requirements for our Index View..." (EN 4.04)
            return View(model); //"4. When we go to that path it will return a view for that path."
        }

        //GET 
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ToDoCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }

    }
}