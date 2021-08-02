using CQRSwithCDC.Read.Dto;
using MediatR;

namespace CQRSwithCDC.Read.Commands
{
	public record DeleteStudent(StudentDto dto) : IRequest<bool>;
}
