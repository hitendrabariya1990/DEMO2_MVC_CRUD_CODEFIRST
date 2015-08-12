using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CRUD_CDFIRST.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CRUD_CDFIRST.DAL
{
    public class SchoolContext:DbContext 
    {
        public SchoolContext():base("SchoolContext")
        {

        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<Course> Course { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }

        public DbSet<Instructor> Instructors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Course>()
                    .HasMany(c => c.Instructors).WithMany(i => i.Courses)
                    .Map(t => t.MapLeftKey("CourseID")
                        .MapRightKey("InstructorID")
                        .ToTable("CourseInstructor"));
        }
    }
}