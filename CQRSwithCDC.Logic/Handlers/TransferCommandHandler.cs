using System;
using System.Threading;
using System.Threading.Tasks;
using CQRSwithCDC.Logic.Commands;
using CQRSwithCDC.Logic.Core;
using CQRSwithCDC.Logic.Infrastructure;
using MediatR;

namespace CQRSwithCDC.Logic.Handlers
{
	public class TransferCommandHandler : IRequestHandler<TransferCommand, Result>
	{
		private readonly DataContext _context;

		public TransferCommandHandler(DataContext context)
		{
			_context = context;
		}
		public async Task<Result> Handle(TransferCommand request, CancellationToken cancellationToken)
		{
			if (!Enum.IsDefined(typeof(Grade), request.TransferDto.Grade)) return ResultFactory.Fail("Grade is invalid");
			var grade = Enum.Parse<Grade>(request.TransferDto.Grade);

			var student = await _context.Students.FindAsync(request.TransferDto.StudentId);
			if (student == null) return ResultFactory.Fail("No student with that id.");
			var course = await _context.Courses.FindAsync(request.TransferDto.CourseId);
			if (course == null) return ResultFactory.Fail("No course with that id.");

			var enrollment = student.GetEnrollment(request.TransferDto.EnrollmentNumber);
			if (enrollment == null) return ResultFactory.Fail("No enrollment with that number.");
			enrollment.Update(course, grade);
			await _context.SaveAllAsync();
			return ResultFactory.Ok();
		}
	}
}
