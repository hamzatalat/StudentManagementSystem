using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
	public class StudentContext
	{
		public DbSet<Student> Students { get; set; }
	}
}