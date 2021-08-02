using CQRSwithCDC.Read.Dto;
using MediatR;

namespace CQRSwithCDC.Read.Commands
{
	public record InsertEnrollment(EnrollmentDto Dto) : IRequest<bool>;
}
