using Microsoft.AspNetCore.Identity;
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
            if (!context.Phones.Any())
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
                Organization raimbek = new Organization
                {
                    Name = "Raimbek",
                    Department = "Almaty"
                };
                Organization raimbek_ns = new Organization
                {
                    Name = "Raimbek",
                    Department = "Nursultan"
                };
                Organization nurzhanar = new Organization
                {
                    Name = "Nurzhanar",
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
                        City = "Almaty",
                        Street = "Abay",
                        Build = "30B",
                        Office = 1
                    },
                    new Room
                    {
                        Country = "Kz",
                        City = "Almaty",
                        Street = "Abay",
                        Build = "33",
                        Office = 3
                    },
                    new Room
                    {
                        Country = "Kz",
                        City = "Uralsk",
                        Street = "Abay",
                        Build = "14",
                        Office = 14
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

                context.Organizations.AddRange(hm, nestle, raimbek, raimbek_ns, nurzhanar);
                context.SaveChanges();

                context.Persons.AddRange(marat, Ivan);
                context.SaveChanges();

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
                        Number = 7774444567,
                        Organization = raimbek,
                        RoomId = 1
                    },
                    new Phone
                    {
                        Number = 7014444567,
                        Organization = raimbek_ns,
                        RoomId = 2
                    },
                    new Phone
                    {
                        Number = 7777774567,
                        Organization = nurzhanar,
                        RoomId = 1
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
