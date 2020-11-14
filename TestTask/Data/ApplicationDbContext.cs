using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestTask.Models;

namespace TestTask.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Phone>()
                .HasOne(p => p.Organization)
                .WithMany(t => t.Phones)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Phone>()
                .HasOne(p => p.Person)
                .WithMany(t => t.Phones)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Phone>()
                .HasOne(p => p.Room)
                .WithMany(t => t.Phones)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
