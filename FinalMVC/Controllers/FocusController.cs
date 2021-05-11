using Final.Models.FocusModels;
using Final.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalMVC.Controllers
{
    public class FocusController : Controller
    {
        [Authorize]
        // GET: Focus
        public ActionResult Index()
        {
            //var model = new ToDoListItem[0];  
            //return View(model);
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FocusService(userId);
            var model = service.GetFocuses();

            return View(model);

        }

        //GET 
        public ActionResult Create()
        {
            return View();
        }


        //CREATE

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FocusCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateFocusService();

            if (service.CreateFocus(model))
            {
                TempData["SaveResult"] = "Your Focus was created!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Focus could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateFocusService();
            var model = svc.GetFocusById(id);

            return View(model);
        }


        public ActionResult Edit(int id)
        {
            var service = CreateFocusService();
            var listItem = service.GetFocusById(id);
            var model =
                new FocusEdit
                {
                    FocusLabel = listItem.FocusLabel,
                    DaysAssignedThisFocus = listItem.DaysAssignedThisFocus
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FocusEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return View(model);
            }

            var service = CreateFocusService();

            if (service.UpdateFocus(model))
            {
                TempData["SaveResult"] = "Your Focus was successfully updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Focus could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateFocusService();
            var model = svc.GetFocusById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateFocusService();

            service.DeleteFocus(id);

            TempData["SaveResult"] = "Your Focus was successfully deleted!";

            return RedirectToAction("Index");
        }


        private FocusService CreateFocusService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FocusService(userId);
            return service;
        }

    }
}