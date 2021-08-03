using System.Collections.Generic;
using System.Threading.Tasks;
using CQRSwithCDC.Logic.Commands;
using CQRSwithCDC.Logic.Dtos;
using CQRSwithCDC.Logic.Handlers;
using CQRSwithCDC.Logic.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSwithCDC.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class StudentsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public StudentsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IEnumerable<StudentDto>> AllStudents()
		{
			return await _mediator.Send(new GetStudentsQuery());
		}

		[HttpGet("{id}")]
		public async Task<StudentDto> Student(long id)
		{
			return await _mediator.Send(new GetStudentQuery(id));
		}

		[HttpPost]
		public async Task<ActionResult<Result>> Register([FromBody] RegisterDto registerDto)
		{
			return Ok(await _mediator.Send(new RegisterCommand(registerDto)));
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<Result>> EditPersonalInfo(long id, [FromBody] PersonalInfoDto dto)
		{
			return Ok(await _mediator.Send(new EditPersonalInfoCommand(new(id, dto.Name, dto.Email))));
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<Result>> Unregister(long id)
		{
			return Ok(await _mediator.Send(new UnregisterCommand(new(id))));
		}

		[HttpPost("{id}/enrollments")]
		public async Task<ActionResult<Result>> Enroll(long id, [FromBody] EnrollDto dto)
		{
			return Ok(await _mediator.Send(new EnrollCommand(new(id, dto.CourseId, dto.Grade))));
		}

		[HttpDelete("{id}/enrollments")]
		public async Task<ActionResult<Result>> Disenroll(long id, [FromBody] DisenrollDto dto)
		{
			return Ok(await _mediator.Send(new DisenrollCommand(new(id, dto.EnrollmentNumber, dto.Comment))));
		}

		[HttpPut("{id}/enrollments")]
		public async Task<ActionResult<Result>> Transfer(long id, [FromBody] TransferDto dto)
		{
			return Ok(await _mediator.Send(new TransferCommand(new(id, dto.EnrollmentNumber, dto.CourseId, dto.Grade))));
		}
	}
}
