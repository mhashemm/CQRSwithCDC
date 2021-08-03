using CQRSwithCDC.Logic.Dtos;
using MediatR;

namespace CQRSwithCDC.Logic.Queries
{
	public record GetStudentQuery(long Id) : IRequest<StudentDto>;
}
