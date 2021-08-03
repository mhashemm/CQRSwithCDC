using System.Threading;
using System.Threading.Tasks;
using CQRSwithCDC.Logic.Dtos;
using CQRSwithCDC.Logic.Queries;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;

namespace CQRSwithCDC.Logic.Handlers
{
	public class GetStudentQueryHandler : IRequestHandler<GetStudentQuery, StudentDto>
	{
		private readonly SqlConnection _connection;

		public GetStudentQueryHandler(SqlConnection connection)
		{
			_connection = connection;
		}
		public async Task<StudentDto> Handle(GetStudentQuery request, CancellationToken cancellationToken)
		{
			var sql = "SELECT * FROM dbo.Students WHERE Id=@Id";
			var student = await _connection.QuerySingleOrDefaultAsync<StudentDto>(sql, new { Id = request.Id });
			return student;
		}
	}
}
