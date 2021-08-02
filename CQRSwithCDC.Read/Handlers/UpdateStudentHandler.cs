using System.Threading;
using System.Threading.Tasks;
using CQRSwithCDC.Read.Commands;
using CQRSwithCDC.Read.Infrastructure;
using MediatR;

namespace CQRSwithCDC.Read.Handlers
{
	public class UpdateStudentHandler : IRequestHandler<UpdateStudent, bool>
	{
		private readonly DataContext _context;

		public UpdateStudentHandler(DataContext context)
		{
			_context = context;
		}
		public async Task<bool> Handle(UpdateStudent request, CancellationToken cancellationToken)
		{
			var student = await _context.Students.FindAsync(request.Dto.Id);
			student.Name = request.Dto.Name;
			student.Email = request.Dto.Email;
			return await _context.SaveAllAsync();
		}
	}
}
