using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestTask.Data;
using TestTask.Models;

namespace TestTask.Controllers
{
    [Authorize(Roles ="admin")]
    public class RoomsController : Controller
    {
        private ApplicationDbContext db;
        public RoomsController(ApplicationDbContext context)
        {
            db = context;
        }
        // GET: RoomsController
        public ActionResult Index()
        {
            return View(db.Rooms.ToList());
        }

        // GET: RoomsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoomsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Room room)
        {
            if (ModelState.IsValid)
            {
                db.Rooms.Add(room);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(room);
        }

        // GET: RoomsController/Edit/5
        public ActionResult Edit(int id)
        {
            Room room = db.Rooms.FirstOrDefault(p => p.Id == id);
            if (room != null)
            {
                return View(room);
            }
            return NotFound();
        }

        // POST: RoomsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Room room)
        {
            if (ModelState.IsValid)
            {
                db.Rooms.Update(room);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(room);

        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Room room = db.Rooms.FirstOrDefault(p => p.Id == id);
                if (room != null)
                    return View(room);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                Room room = db.Rooms.FirstOrDefault(p => p.Id == id);
                if (room != null)
                {
                    db.Rooms.Remove(room);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}
