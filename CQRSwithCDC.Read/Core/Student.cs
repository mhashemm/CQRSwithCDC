namespace CQRSwithCDC.Read.Core
{
	public class Student
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public byte NumberOfEnrollments { get; set; }
		public string FirstCourseName { get; set; }
		public byte FirstCourseCredits { get; set; }
		public byte FirstCourseGrade { get; set; }
		public string SecondCourseName { get; set; }
		public byte SecondCourseCredits { get; set; }
		public byte SecondCourseGrade { get; set; }
		public Student(long id, string name, string email)
		{
			Id = id;
			Name = name;
			Email = email;
		}
	}
}
