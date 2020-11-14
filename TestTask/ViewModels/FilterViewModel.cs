using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Models;

namespace TestTask.ViewModels
{
    public class FilterViewModel
    {
        public FilterViewModel(long? number, List<Organization> orgs, int? orgId, List<Person> persons, int? personId, List<Room> rooms, int? roomId)
        {
            // устанавливаем начальный элемент, который позволит выбрать всех
            orgs.Insert(0, new Organization { Name = "Все", Id = 0 });
            Organizations = new SelectList(orgs, "Id", "Name", orgId);
            SelectedOrg = orgId;
            SelectedNumber = number;
            persons.Insert(0, new Person { FullName = "Выберите ФИО", Id = 0 });
            Persons = new SelectList(persons, "Id", "FullName", personId);
            PersonId = personId;
            rooms.Insert(0, new Room { FullAddress = "Все", Id = 0 });
            Rooms = new SelectList(rooms, "Id", "FullAddress", roomId);
            RoomId = roomId;
        }
        public SelectList Organizations { get; private set; } // список компаний
        public int? SelectedOrg { get; private set; }   // выбранная компания
        public long? SelectedNumber { get; private set; }    // введенный номер
        public SelectList Persons { get; private set; }
        public int? PersonId { get; private set; }
        public SelectList Rooms { get; private set; }
        public int? RoomId { get; private set; }
    }
}
