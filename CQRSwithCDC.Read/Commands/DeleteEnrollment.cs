using CQRSwithCDC.Read.Dto;
using MediatR;

namespace CQRSwithCDC.Read.Commands
{
	public record DeleteEnrollment(EnrollmentDto Dto) : IRequest<bool>;
}
