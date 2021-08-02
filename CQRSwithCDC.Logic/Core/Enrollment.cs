using System;

namespace CQRSwithCDC.Logic.Core
{
	public class Enrollment : Entity
	{
		public Student Student { get; init; }
		public Course Course { get; protected set; }
		public byte Grade { get; protected set; }

		protected Enrollment()
		{
		}

		public Enrollment(Student student, Course course, byte grade)
				: this()
		{
			Student = student;
			Course = course;
			Grade = GuardGrade(grade);
		}

		public void Update(Course course, byte grade)
		{
			Course = course;
			Grade = GuardGrade(grade);
		}

		private byte GuardGrade(byte grade)
		{
			if (grade is < 0 or > 4)
				throw new ArgumentOutOfRangeException("Grade must be in range of 0 and 4");
			return grade;
		}
	}
}
