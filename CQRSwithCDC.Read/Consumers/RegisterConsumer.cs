using System.Threading.Tasks;
using Confluent.Kafka;
using CQRSwithCDC.Read.Commands;
using CQRSwithCDC.Read.Dto;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CQRSwithCDC.Read.Consumers
{
	class RegisterConsumer : Consumer<object>
	{
		private readonly IMediator _mediator;

		public RegisterConsumer(IConsumer<string, string> consumer, ILogger<RegisterConsumer> logger, IMediator mediator) : base(consumer, logger)
		{
			_consumer.Subscribe(new[] { "CQRSwithCDC_Write.dbo.Enrollments", "CQRSwithCDC_Write.dbo.Students" });
			_mediator = mediator;
		}

		protected override async Task<bool> Consume(Message<object> message)
		{
			IRequest<bool> command = message.source.table switch
			{
				"Students" => StudentTable(message),
				"Enrollments" => EnrollmentTable(message),
				_ => null
			};

			return await _mediator.Send(command);
		}
		private IRequest<bool> StudentTable(Message<object> message)
		{
			var after = message.after?.ToString().JsonDeserialize<StudentDto>();
			var before = message.before?.ToString().JsonDeserialize<StudentDto>();
			IRequest<bool> command = message.op switch
			{
				'c' => new InsertStudent(after),
				'u' => new UpdateStudent(after),
				'd' => new DeleteStudent(before),
				'r' => before == null ? new InsertStudent(after) :
								after == null ? new DeleteStudent(before) :
								new UpdateStudent(after),
				_ => null
			};
			return command;
		}

		private IRequest<bool> EnrollmentTable(Message<object> message)
		{
			var after = message.after?.ToString().JsonDeserialize<EnrollmentDto>();
			var before = message.before?.ToString().JsonDeserialize<EnrollmentDto>();
			IRequest<bool> command = message.op switch
			{
				'c' => new InsertEnrollment(after),
				'u' => new UpdateEnrollment(before, after),
				'd' => new DeleteEnrollment(before),
				'r' => before == null ? new InsertEnrollment(after) :
								after == null ? new DeleteEnrollment(before) :
								new UpdateEnrollment(before, after),
				_ => null
			};
			return command;
		}
	}
}
