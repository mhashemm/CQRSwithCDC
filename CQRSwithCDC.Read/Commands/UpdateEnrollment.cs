using CQRSwithCDC.Read.Dto;
using MediatR;

namespace CQRSwithCDC.Read.Commands
{
	public record UpdateEnrollment(EnrollmentDto Before, EnrollmentDto After) : IRequest<bool>;
}
