using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CQRSwithCDC.Logic.Dtos;
using CQRSwithCDC.Logic.Queries;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;

namespace CQRSwithCDC.Logic.Handlers
{
	public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, IEnumerable<StudentDto>>
	{
		private readonly SqlConnection _connection;

		public GetStudentsQueryHandler(SqlConnection connection)
		{
			_connection = connection;
		}
		public async Task<IEnumerable<StudentDto>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
		{
			var sql = "SELECT * FROM dbo.Students WHERE Name IS NOT NULL";
			var students = await _connection.QueryAsync<StudentDto>(sql);
			return await Task.FromResult(students);
		}
	}
}
