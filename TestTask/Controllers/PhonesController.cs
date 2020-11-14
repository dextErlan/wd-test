using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.ViewModels;

namespace TestTask.Controllers
{
    [Authorize(Roles = "admin")]
    public class PhonesController : Controller
    {
        private ApplicationDbContext db;
        public PhonesController(ApplicationDbContext context)
        {
            db = context;
        }

        // GET: PhonesController
        public ActionResult Index()
        {
            return View(db.Phones.Include(p => p.Organization).Include(p => p.Person).Include(p => p.Room));
        }
        private void initDropdownData(Phone p=null) 
        {
            List<Organization> orgs = db.Organizations.ToList();
            orgs.Insert(0, new Organization { Name = "Выберите организацию", Id = 0 });            
            ViewBag.Organizations = new SelectList(orgs, "Id", "Name", p?.OrganizationId);


            List<Person> persons = db.Persons.ToList();
            persons.Insert(0, new Person { FullName = "Выберите ФИО", Id = 0 });
            ViewBag.Persons = new SelectList(persons, "Id", "FullName", p?.PersonId);

            List<Room> rooms = db.Rooms.ToList();
            rooms.Insert(0, new Room { FullAddress = "Выберите адрес", Id = 0 });
            ViewBag.Rooms = new SelectList(rooms, "Id", "FullAddress", p?.RoomId);
        }

        // GET: PhonesController/Create
        public ActionResult Create()
        {
            initDropdownData();

            return View();
        }

        // POST: PhonesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Phone p)
        {
            initDropdownData();

            if (p.Number>0 && (p.OrganizationId!=0 || p.PersonId!=0) && !(p.OrganizationId > 0 && p.PersonId > 0) && p.RoomId!=0)
            {
                if (p.OrganizationId == 0) p.OrganizationId = null;
                if (p.PersonId == 0) p.PersonId = null;
                db.Phones.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
        }

        // GET: PhonesController/Edit/5()
        public ActionResult Edit(int id)
        {
            Phone phone = db.Phones.FirstOrDefault(p => p.Id == id);
            if (phone != null)
            {
                initDropdownData(phone);
                return View(phone);
            }
            return NotFound();
        }

        // POST: PhonesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Phone p)
        {
            if (p.Number > 0 && (p.OrganizationId != 0 || p.PersonId != 0) && !(p.OrganizationId > 0 && p.PersonId > 0) && p.RoomId != 0)
            {
                if (p.OrganizationId == 0) p.OrganizationId = null;
                if (p.PersonId == 0) p.PersonId = null;
                db.Phones.Update(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            initDropdownData(p);
            return View(p);

        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Phone phone = db.Phones.FirstOrDefault(p => p.Id == id);
                if (phone != null)
                    return View(phone);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                Phone phone = db.Phones.FirstOrDefault(p => p.Id == id);
                if (phone != null)
                {
                    db.Phones.Remove(phone);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}
