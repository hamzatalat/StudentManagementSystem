using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
	public class AssignCourse
	{
		[Key]
		public int StudentId { get; set; }
		public int CourseId { get; set; }
	}
}