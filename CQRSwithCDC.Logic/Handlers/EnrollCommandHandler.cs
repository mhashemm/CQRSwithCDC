using System.Threading;
using System.Threading.Tasks;
using CQRSwithCDC.Logic.Commands;
using CQRSwithCDC.Logic.Infrastructure;
using MediatR;

namespace CQRSwithCDC.Logic.Handlers
{
	public class EnrollCommandHandler : IRequestHandler<EnrollCommand, Result>
	{
		private readonly DataContext _context;

		public EnrollCommandHandler(DataContext context)
		{
			_context = context;
		}
		public async Task<Result> Handle(EnrollCommand request, CancellationToken cancellationToken)
		{
			var student = await _context.Students.FindAsync(request.EnrollDto.StudentId);
			if (student == null) return ResultFactory.Fail("No student with that id.");
			var course = await _context.Courses.FindAsync(request.EnrollDto.CourseId);
			if (course == null) return ResultFactory.Fail("No course with that id.");
			student.Enroll(course, request.EnrollDto.Grade);
			await _context.SaveAllAsync();
			return ResultFactory.Ok();
		}
	}
}
