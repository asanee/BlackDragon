using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlackDragon.TimeSheets.Mvc.Models;
using BlackDragon.TimeSheets.Domain;
using BlackDragon.TimeSheets.Shared;
using System.Web.Routing;

namespace BlackDragon.TimeSheets.Mvc.Controllers
{
    [HandleError]
    public class CircleController : Controller
    {
        public CircleController(ICircleService service)
        {
            CircleService = service;
        }

        public ActionResult Index()
        {
            return View();
        }
                
        public ActionResult Details(long id)
        {
            var circle = CircleService.GetCircle(id, User.Identity.Name);

            return View(circle);
        }

        //
        // GET: /Circle/Create

        [Authorize]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Circle/Create

        [Authorize]
        [HttpPost]
        public ActionResult Create(CircleFullDto model)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                var circle = CircleService.Create(model.Name, User.Identity.Name);

                var dict = new RouteValueDictionary();

                dict.Add("id", circle.ID);

                return RedirectToAction("Details", "Circle", routeValues: dict );
            }
            catch(DomainException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
        
        //
        // GET: /Circle/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Circle/Edit/5

        [HttpPost]
        public ActionResult Edit(long id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Circle/Delete/5

        public ActionResult Delete(long id)
        {
            return View();
        }

        //
        // POST: /Circle/Delete/5

        [HttpPost]
        public ActionResult Delete(long id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ICircleService CircleService { get; private set; }
    }
}
