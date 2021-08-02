using CQRSwithCDC.Read.Dto;
using MediatR;

namespace CQRSwithCDC.Read.Commands
{
	public record UpdateStudent(StudentDto Dto) : IRequest<bool>;
}
