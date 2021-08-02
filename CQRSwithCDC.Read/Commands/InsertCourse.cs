using CQRSwithCDC.Read.Dto;
using MediatR;

namespace CQRSwithCDC.Read.Commands
{
	public record InsertCourse(CourseDto Dto) : IRequest<bool>;
}
