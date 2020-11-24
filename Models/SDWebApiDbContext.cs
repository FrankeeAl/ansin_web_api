using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SharpDevelopWebApi.Models
{
    public class SDWebApiDbContext : DbContext
    {
        public SDWebApiDbContext() : base("ansinDb") // DefaultConn ansinDb
        {
        }

        // Map model classes to database tables
        public DbSet<UserAccount> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Subject> Subjects { get; set; }

    }


}

