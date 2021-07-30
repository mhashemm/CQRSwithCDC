using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSwithCDC.Read.Core
{
	public class Student
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public int NumberOfEnrollments { get; set; }
		public string FirstCourseName { get; set; }
		public int FirstCourseCredits { get; set; }
		public int FirstCourseGrade { get; set; }
		public string SecondCourseName { get; set; }
		public int SecondCourseCredits { get; set; }
		public int SecondCourseGrade { get; set; }
	}
}
