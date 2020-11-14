using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestTask.Data;
using TestTask.Models;
using TestTask.ViewModels;

namespace TestTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        ApplicationDbContext db;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            db = context;
        }

        public async Task<IActionResult> Index(long? number, int? orgId, int? personId, int? roomId, int page = 1, SortState sortOrder = SortState.NumberAsc)
        {
            int pageSize = 3;

            IQueryable<Phone> phones = Filter(number, orgId, personId, roomId);

            // сортировка
            switch (sortOrder)
            {
                case SortState.NumberDesc:
                    phones = phones.OrderByDescending(s => s.Number);
                    break;
                case SortState.OrgAsc:
                    phones = phones.OrderBy(s => s.Organization.Name);
                    break;
                case SortState.OrgDesc:
                    phones = phones.OrderByDescending(s => s.Organization.Name);
                    break;
                default:
                    phones = phones.OrderBy(s => s.Number);
                    break;
            }

            // пагинация
            var count = await phones.CountAsync();
            var items = await phones.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // формируем модель представления
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(number, db.Organizations.ToList(), orgId, db.Persons.ToList(), personId, db.Rooms.ToList(), roomId),
                Phones = items
            };
            return View(viewModel);
        }

        private IQueryable<Phone> Filter(long? number, int? orgId, int? personId, int? roomId)
        {
            //фильтрация
            IQueryable<Phone> phones = db.Phones.Include(x => x.Organization);


            if (number != null && number != 0)
            {
                phones = phones.Where(p => EF.Functions.Like(p.Number.ToString(), "%"+number.ToString()+"%"));
            }
            if (orgId != null && orgId != 0)
            {
                phones = phones.Where(p => p.OrganizationId == orgId);
            }
            if (personId != null && personId != 0)
            {
                phones = phones.Where(p => p.PersonId == personId);
            }
            if (roomId != null && roomId != 0)
            {
                phones = phones.Where(p => p.RoomId == roomId);
            }
            return phones;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
