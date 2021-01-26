using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
	public class Course
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }
		public int CreditHours { get; set; }
		public string Discription { get; set; }
	}
}