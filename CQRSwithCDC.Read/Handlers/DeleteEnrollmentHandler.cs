using System.Threading;
using System.Threading.Tasks;
using CQRSwithCDC.Read.Commands;
using CQRSwithCDC.Read.Infrastructure;
using MediatR;

namespace CQRSwithCDC.Read.Handlers
{
	public class DeleteEnrollmentHandler : IRequestHandler<DeleteEnrollment, bool>
	{
		private readonly DataContext _context;

		public DeleteEnrollmentHandler(DataContext context)
		{
			_context = context;
		}
		public async Task<bool> Handle(DeleteEnrollment request, CancellationToken cancellationToken)
		{
			var student = await _context.Students.FindAsync(request.Dto.StudentID);
			if (student == null) return await Task.FromResult(true);
			var course = await _context.Courses.FindAsync(request.Dto.CourseID);
			if (student.FirstCourseName == course.Name)
			{
				student.FirstCourseName = null;
				student.FirstCourseCredits = 0;
				student.FirstCourseGrade = 0;
			}
			else if (student.SecondCourseName == course.Name)
			{
				student.SecondCourseName = null;
				student.SecondCourseCredits = 0;
				student.SecondCourseGrade = 0;
			}
			student.NumberOfEnrollments--;
			return await _context.SaveAllAsync();
		}
	}
}
