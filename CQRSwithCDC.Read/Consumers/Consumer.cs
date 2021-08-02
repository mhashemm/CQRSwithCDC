using System;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CQRSwithCDC.Read.Consumers
{
	public abstract class Consumer<T> : BackgroundService where T : class
	{
		protected readonly IConsumer<string, string> _consumer;
		private readonly ILogger<Consumer<T>> _logger;

		public Consumer(IConsumer<string, string> consumer, ILogger<Consumer<T>> logger)
		{
			_consumer = consumer;
			_logger = logger;
		}
		protected abstract Task<bool> Consume(Message<T> message);
		protected override sealed async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			try
			{
				while (!stoppingToken.IsCancellationRequested)
				{
					var consumer = _consumer.Consume(stoppingToken);
					if (string.IsNullOrEmpty(consumer.Message.Value))
					{
						_logger.LogInformation("Empty message.");
						continue;
					}
					var obj = consumer.Message.Value.JsonDeserialize<Message<T>>();
					_logger.LogInformation(consumer.Message.Value);
					if (await Consume(obj)) _consumer.Commit();
				}
			}
			catch (Exception e)
			{
				_logger.LogError(e.Message);
			}
			finally
			{
				_consumer.Close();
				_consumer.Dispose();
				_logger.LogInformation($"Closed and disposed consumer.");
			}
		}
	}
}
