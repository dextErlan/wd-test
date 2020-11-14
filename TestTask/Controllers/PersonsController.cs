using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestTask.Data;
using TestTask.Models;

namespace TestTask.Controllers
{
    [Authorize(Roles = "admin")]
    public class PersonsController : Controller
    {
        private ApplicationDbContext db;
        public PersonsController(ApplicationDbContext context)
        {
            db = context;
        }
        // GET: PersonsController
        public ActionResult Index()
        {
            return View(db.Persons.ToList());
        }

        // GET: PersonsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                db.Persons.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: PersonsController/Edit/5
        public ActionResult Edit(int id)
        {
            Person person = db.Persons.FirstOrDefault(p => p.Id == id);
            if (person != null)
            {
                return View(person);
            }
            return NotFound();
        }

        // POST: PersonsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                db.Persons.Update(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);

        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Person person = db.Persons.FirstOrDefault(p => p.Id == id);
                if (person != null)
                    return View(person);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                Person person = db.Persons.FirstOrDefault(p => p.Id == id);
                if (person != null)
                {
                    db.Persons.Remove(person);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}
