using System.Threading;
using System.Threading.Tasks;
using CQRSwithCDC.Read.Commands;
using CQRSwithCDC.Read.Core;
using CQRSwithCDC.Read.Infrastructure;
using MediatR;

namespace CQRSwithCDC.Read.Handlers
{
	public class InsertCourseHandler : IRequestHandler<InsertCourse, bool>
	{
		private readonly DataContext _context;

		public InsertCourseHandler(DataContext context)
		{
			_context = context;
		}
		public async Task<bool> Handle(InsertCourse request, CancellationToken cancellationToken)
		{
			var course = await _context.Courses.FindAsync(request.Dto.Id);
			if (course != null) return await Task.FromResult(true);
			course = new Course(request.Dto.Id, request.Dto.Name, request.Dto.Credits);
			await _context.Courses.AddAsync(course);
			return await _context.SaveAllAsync();
		}
	}
}
