namespace CQRSwithCDC.Logic.Core
{
	public class Enrollment : Entity
	{
		public Student Student { get; protected set; }
		public Course Course { get; protected set; }
		public Grade Grade { get; protected set; }

		protected Enrollment()
		{
		}

		public Enrollment(Student student, Course course, Grade grade)
				: this()
		{
			Student = student;
			Course = course;
			Grade = grade;
		}

		public void Update(Course course, Grade grade)
		{
			Course = course;
			Grade = grade;
		}
	}
}
