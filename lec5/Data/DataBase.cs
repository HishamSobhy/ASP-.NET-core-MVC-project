using lec5.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lec5.Data
{
    public class DataBase : DbContext
    {

        public DataBase()
        {

        }

        public DataBase(DbContextOptions options) : base(options)
        {

        }

       
        public DbSet<User> Users { get; set; }
        public DbSet<role> Roles { get; set; }
        //علشان اقدر استخدمها علشان اعمل ال جدول بتاعي 
        public DbSet<Student> students { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<courses> coursess { get; set; }

        public DbSet<StudentCourses> StudentCoursess { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=ITI_Db;trusted_connection=true;");
            base.OnConfiguring(optionsBuilder);
        }

    


        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<StudentCourses>()
                .HasKey(a => new { a.StudentId, a.coursesId });



            modelBuilder.Entity<courses>().HasKey(a => a.Cour_Id);
            modelBuilder.Entity<courses>()
                .Property(a => a.Cour_name)
                .HasMaxLength(50)
                .IsRequired(); 

            //modelBuilder.Entity<Department>().HasKey(a => a.Dept_Id);
            //modelBuilder.Entity<Department>()
            //    .Property(a => a.Dept_Name)
            //    .HasMaxLength(50)
            //    .IsRequired();

            base.OnModelCreating(modelBuilder);
        
        }
    }
}
