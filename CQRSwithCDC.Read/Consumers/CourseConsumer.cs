using System.Threading.Tasks;
using Confluent.Kafka;
using CQRSwithCDC.Read.Commands;
using CQRSwithCDC.Read.Dto;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CQRSwithCDC.Read.Consumers
{
	class CourseConsumer : Consumer<CourseDto>
	{
		private readonly IMediator _mediator;

		public CourseConsumer(IConsumer<string, string> consumer, ILogger<CourseConsumer> logger, IMediator mediator) : base(consumer, logger)
		{
			_mediator = mediator;
			_consumer.Subscribe("CQRSwithCDC_Write.dbo.Courses");
		}
		protected override async Task<bool> Consume(Message<CourseDto> message)
		{
			return await _mediator.Send(new InsertCourse(message.after));
		}
	}
}
