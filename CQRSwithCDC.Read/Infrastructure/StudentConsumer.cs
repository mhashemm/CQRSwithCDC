using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;

namespace CQRSwithCDC.Read.Infrastructure
{
	public class StudentConsumer : IHostedService
	{
		private readonly string _topic = "CQRSwithCDC_Write.dbo.Students";
		public Task StartAsync(CancellationToken cancellationToken)
		{
			var conf = new ConsumerConfig
			{
				GroupId = "consumer_cqrswithcdc",
				BootstrapServers = "kafka:9092",
				AutoOffsetReset = AutoOffsetReset.Earliest,
				EnableAutoCommit = false
			};
			using (var builder = new ConsumerBuilder<Ignore, string>(conf).Build())
			{
				builder.Subscribe(_topic);
				try
				{
					while (!cancellationToken.IsCancellationRequested)
					{
						var consumer = builder.Consume(cancellationToken);
						Console.WriteLine(consumer.Message.Value);
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
					builder.Close();
				}
			}
			return Task.CompletedTask;
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			return Task.CompletedTask;
		}
	}
}
