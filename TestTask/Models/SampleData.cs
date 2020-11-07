using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Data;

namespace TestTask.Models
{
    public class SampleData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            Organization hm = new Organization
            {
                Name = "H&M",
                Department = "one"
            };
            Organization nestle = new Organization
            {
                Name = "Nestle",
                Department = ""
            };
            Person marat = new Person
            {
                FirstName = "Marat",
                MiddleName = "Nurlan uli",
                LastName = "Saparov"
            };
            Person Ivan = new Person
            {
                FirstName = "Ivan",
                MiddleName = "Ivanovich",
                LastName = "Ivanov"
            };
            if (!context.Rooms.Any())
            {
                context.Rooms.AddRange(
                    new Room
                    {
                        Country = "Kz",
                        City = "Almaty",
                        Street = "Abay",
                        Build = "25B",
                        Office = 2
                    },
                    new Room
                    {
                        Country = "Kz",
                        City = "Almaty",
                        Street = "Abay",
                        Build = "25B",
                        Office = 3
                    },
                    new Room
                    {
                        Country = "Kz",
                        City = "Uralsk",
                        Street = "Abay",
                        Build = "12",
                        Office = 1
                    },
                    new Room
                    {
                        Country = "Kz",
                        City = "Uralsk",
                        Street = "Dostyk",
                        Build = "4",
                        Office = 7
                    });
                context.SaveChanges();
            }
            if (!context.Organizations.Any())
            {
                context.Organizations.AddRange(hm, nestle);
                context.SaveChanges();
            }
            if (!context.Persons.Any())
            {
                context.Persons.AddRange(marat, Ivan);
                context.SaveChanges();
            }
            if (!context.Phones.Any())
            {
                context.Phones.AddRange(
                    new Phone
                    {
                        Number = 7771234567,
                        Organization = hm,
                        RoomId = 1
                    },
                    new Phone
                    {
                        Number = 7011234567,
                        Organization = nestle,
                        RoomId = 2
                    },
                    new Phone
                    {
                        Number = 7471234567,
                        Person = marat,
                        RoomId = 3
                    },
                    new Phone
                    {
                        Number = 7081234567,
                        Person = Ivan,
                        RoomId = 4
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
