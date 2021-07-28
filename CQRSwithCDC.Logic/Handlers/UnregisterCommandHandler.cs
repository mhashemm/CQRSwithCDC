using System.Threading;
using System.Threading.Tasks;
using CQRSwithCDC.Logic.Commands;
using CQRSwithCDC.Logic.Infrastructure;
using MediatR;

namespace CQRSwithCDC.Logic.Handlers
{
	public class UnregisterCommandHandler : IRequestHandler<UnregisterCommand, Result>
	{
		private readonly DataContext _context;

		public UnregisterCommandHandler(DataContext context)
		{
			_context = context;
		}
		public async Task<Result> Handle(UnregisterCommand request, CancellationToken cancellationToken)
		{
			var student = await _context.Students.FindAsync(request.UnregisterDto.Id);
			if (student == null) return ResultFactory.Fail("No student with that id.");

			_context.Students.Remove(student);
			await _context.SaveAllAsync();
			return ResultFactory.Ok();
		}
	}
}
