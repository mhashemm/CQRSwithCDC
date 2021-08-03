using System.Collections.Generic;
using CQRSwithCDC.Logic.Dtos;
using MediatR;

namespace CQRSwithCDC.Logic.Queries
{
	public record GetStudentsQuery() : IRequest<IEnumerable<StudentDto>>;
}
