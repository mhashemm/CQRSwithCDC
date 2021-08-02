using System.Threading;
using System.Threading.Tasks;
using CQRSwithCDC.Read.Commands;
using CQRSwithCDC.Read.Core;
using CQRSwithCDC.Read.Infrastructure;
using MediatR;

namespace CQRSwithCDC.Read.Handlers
{
	public class InsertEnrollmentHandler : IRequestHandler<InsertEnrollment, bool>
	{
		private readonly DataContext _context;

		public InsertEnrollmentHandler(DataContext context)
		{
			_context = context;
		}
		public async Task<bool> Handle(InsertEnrollment request, CancellationToken cancellationToken)
		{
			var course = await _context.Courses.FindAsync(request.Dto.CourseID);
			var student = await _context.Students.FindAsync(request.Dto.StudentID);
			if (student == null)
			{
				student = new Student(request.Dto.StudentID, "", "");
				await _context.Students.AddAsync(student);
			}
			if (string.IsNullOrEmpty(student.FirstCourseName))
			{
				student.FirstCourseName = course.Name;
				student.FirstCourseCredits = course.Credits;
				student.FirstCourseGrade = request.Dto.Grade;
			}
			else if (string.IsNullOrEmpty(student.SecondCourseName))
			{
				student.SecondCourseName = course.Name;
				student.SecondCourseCredits = course.Credits;
				student.SecondCourseGrade = request.Dto.Grade;
			}
			student.NumberOfEnrollments++;
			return await _context.SaveAllAsync();
		}
	}
}
