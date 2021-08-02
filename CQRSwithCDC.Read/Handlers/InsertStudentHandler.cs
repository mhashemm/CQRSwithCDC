using System.Threading;
using System.Threading.Tasks;
using CQRSwithCDC.Read.Commands;
using CQRSwithCDC.Read.Core;
using CQRSwithCDC.Read.Infrastructure;
using MediatR;

namespace CQRSwithCDC.Read.Handlers
{
	public class InsertStudentHandler : IRequestHandler<InsertStudent, bool>
	{
		private readonly DataContext _context;

		public InsertStudentHandler(DataContext context)
		{
			_context = context;
		}
		public async Task<bool> Handle(InsertStudent request, CancellationToken cancellationToken)
		{
			var student = await _context.Students.FindAsync(request.Dto.Id);
			if (student == null)
			{
				student = new Student(request.Dto.Id, request.Dto.Name, request.Dto.Email);
				await _context.Students.AddAsync(student);
			}
			else
			{
				student.Name = request.Dto.Name;
				student.Email = request.Dto.Email;
			}
			return await _context.SaveAllAsync();
		}
	}
}
