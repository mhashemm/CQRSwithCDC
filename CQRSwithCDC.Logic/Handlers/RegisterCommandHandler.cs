using System.Threading;
using System.Threading.Tasks;
using CQRSwithCDC.Logic.Commands;
using CQRSwithCDC.Logic.Core;
using CQRSwithCDC.Logic.Infrastructure;
using MediatR;

namespace CQRSwithCDC.Logic.Handlers
{
	public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result>
	{
		private readonly DataContext _context;

		public RegisterCommandHandler(DataContext context)
		{
			_context = context;
		}
		public async Task<Result> Handle(RegisterCommand request, CancellationToken cancellationToken)
		{
			var student = new Student(request.RegisterDto.Name, request.RegisterDto.Email);

			foreach (var courseToRegister in request.RegisterDto.Courses)
			{
				var course = await _context.Courses.FindAsync(courseToRegister.CourseId);
				if (course == null) return ResultFactory.Fail("No course with that id.");
				student.Enroll(course, courseToRegister.Grade);
			}
			await _context.Students.AddAsync(student);
			await _context.SaveAllAsync();
			return ResultFactory.Ok();
		}
	}
}
