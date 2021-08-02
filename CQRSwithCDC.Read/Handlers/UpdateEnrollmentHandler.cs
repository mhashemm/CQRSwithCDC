using System.Threading;
using System.Threading.Tasks;
using CQRSwithCDC.Read.Commands;
using CQRSwithCDC.Read.Infrastructure;
using MediatR;

namespace CQRSwithCDC.Read.Handlers
{
	public class UpdateEnrollmentHandler : IRequestHandler<UpdateEnrollment, bool>
	{
		private readonly DataContext _context;

		public UpdateEnrollmentHandler(DataContext context)
		{
			_context = context;
		}
		public async Task<bool> Handle(UpdateEnrollment request, CancellationToken cancellationToken)
		{
			var student = await _context.Students.FindAsync(request.After.StudentID);
			var beforeCourse = await _context.Courses.FindAsync(request.Before.CourseID);
			var afterCourse = await _context.Courses.FindAsync(request.After.CourseID);
			if (student.FirstCourseName == beforeCourse.Name)
			{
				student.FirstCourseName = afterCourse.Name;
				student.FirstCourseCredits = afterCourse.Credits;
				student.FirstCourseGrade = request.After.Grade;
			}
			else if (student.SecondCourseName == beforeCourse.Name)
			{
				student.SecondCourseName = afterCourse.Name;
				student.SecondCourseCredits = afterCourse.Credits;
				student.SecondCourseGrade = request.After.Grade;
			}
			return await _context.SaveAllAsync();
		}
	}
}
