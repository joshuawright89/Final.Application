using Final.Models;
using Final.Models.TaskModels;
using Final.Models.ToDoModels;
using Final.Services;
using Microsoft.AspNet.Identity;
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
        public ActionResult Index() 
        {
            //var model = new ToDoListItem[0];  
            //return View(model);
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ToDoService(userId);
            var model = service.GetAllToDos();

            return View(model);
        
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
            if (!ModelState.IsValid) return View(model);

            var service = CreateToDoService();

            if (service.CreateToDo(model))
            {
                TempData["SaveResult"] = "Your Task was created!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Task could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateToDoService();
            var model = svc.GetToDoById(id);

            return View(model);
        }


        public ActionResult Edit(int id)
        {
            var service = CreateToDoService();
            var listItem = service.GetToDoById(id);
            var model =
                new ToDoEdit
                {
                    ToDoName = listItem.ToDoName,
                    DaysAssignedThisToDo = listItem.DaysAssignedThisToDo
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ToDoEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.Id != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return View(model);
            }

            var service = CreateToDoService();

            if (service.UpdateToDo(model))
            {
                TempData["SaveResult"] = "Your note was successfully updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateToDoService();
            var model = svc.GetToDoById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateToDoService();

            service.DeleteToDo(id);

            TempData["SaveResult"] = "Your task was successfully deleted!";

            return RedirectToAction("Index");
        }


        private ToDoService CreateToDoService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ToDoService(userId);
            return service;
        }
    }
}