using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public long Number { get; set; }
        //public int? OrganizationId { get; set; } // ссылка на связанную модель Organization
        public Organization Organization { get; set; }
        //public int? PersonId { get; set; } // ссылка на связанную модель Person
        public Person Person { get; set; }
        public int RoomId { get; set; } // ссылка на связанную модель Room
        public Room Room { get; set; }
    }
}
