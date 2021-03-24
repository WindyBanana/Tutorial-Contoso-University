using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tutorial_Contoso_University.Models;


/*
 The main class that coordinates EF Core functionality for a given data model is the database context class. 
 The context is derived from Microsoft.EntityFrameworkCore.DbContext. 
 The context specifies which entities are included in the data model. 
 In this project, the class is named SchoolContext
 */
namespace ContosoUniversity.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext (DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }


        /*
         Referring to the codesection below:
        The code below creates a DbSet<TEntity> property for each entity set. In EF Core terminology:

        - An entity set typically corresponds to a database table.
        - An entity corresponds to a row in the table.
        
        Since an entity set contains multiple entities, the DBSet properties should be plural names. Since the scaffolding tool created aStudent DBSet, this step changes it to plural Students.

        To make the Razor Pages code match the new DBSet name, make a global change across the whole project of _context.Student to _context.Students. There are 8 occurrences.
         */
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<CourseAssignment> CourseAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Instructor>().ToTable("Instructor");
            modelBuilder.Entity<OfficeAssignment>().ToTable("OfficeAssignment");
            modelBuilder.Entity<CourseAssignment>().ToTable("CourseAssignment");

            modelBuilder.Entity<CourseAssignment>()
                .HasKey(c => new { c.CourseID, c.InstructorID });
        }
    }
}
