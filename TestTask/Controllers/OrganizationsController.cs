using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Data;
using TestTask.Models;

namespace TestTask.Controllers
{
    [Authorize(Roles ="admin")]
    public class OrganizationsController: Controller
    {
        private ApplicationDbContext db;
        public OrganizationsController(ApplicationDbContext context)
        {
            db = context;
        }
        public IActionResult Index() => View(db.Organizations.ToList());

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Organization org)
        {
            if(ModelState.IsValid)
            {
                db.Organizations.Add(org);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(org);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Organization org = db.Organizations.FirstOrDefault(o => o.Id == id);
            if(org!=null)
            {
                return View(org);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Organization org)
        {
            if (ModelState.IsValid)
            {
                db.Organizations.Update(org);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(org);
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Organization org = db.Organizations.FirstOrDefault(o => o.Id == id);
                if (org != null)
                    return View(org);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                Organization org = db.Organizations.FirstOrDefault(p => p.Id == id);
                if (org != null)
                {
                    db.Organizations.Remove(org);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

    }
}
