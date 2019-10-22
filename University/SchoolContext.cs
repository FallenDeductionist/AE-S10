using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using University.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;

namespace University
{
	public class SchoolContext : DbContext
	{
		public SchoolContext() : base("name = MyContextDB")
		{

		}

		public DbSet<Course> Courses { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<Enrollment> Enrollments { get; set; }
		public DbSet<Instructor> Instructors { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
		public DbSet<Person> People { get; set; }

	}
}