using System.Threading;
using System.Threading.Tasks;
using CQRSwithCDC.Read.Commands;
using CQRSwithCDC.Read.Infrastructure;
using MediatR;

namespace CQRSwithCDC.Read.Handlers
{
	public class DeleteStudentHandler : IRequestHandler<DeleteStudent, bool>
	{
		private readonly DataContext _context;

		public DeleteStudentHandler(DataContext context)
		{
			_context = context;
		}
		public async Task<bool> Handle(DeleteStudent request, CancellationToken cancellationToken)
		{
			var student = await _context.Students.FindAsync(request.dto.Id);
			_context.Remove(student);
			return await _context.SaveAllAsync();
		}
	}
}
