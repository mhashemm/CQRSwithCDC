using CQRSwithCDC.Read.Dto;
using MediatR;

namespace CQRSwithCDC.Read.Commands
{
	public record InsertStudent(StudentDto Dto) : IRequest<bool>;
}
