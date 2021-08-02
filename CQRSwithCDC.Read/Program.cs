using Confluent.Kafka;
using CQRSwithCDC.Read.Consumers;
using CQRSwithCDC.Read.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CQRSwithCDC.Read
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
				Host.CreateDefaultBuilder(args)
						.ConfigureServices((hostContext, services) =>
						{
							services.AddTransient((_) => new ConsumerBuilder<string, string>(new ConsumerConfig
							{
								GroupId = "consumer_cqrswithcdc",
								BootstrapServers = hostContext.Configuration.GetConnectionString("Kafka"),
								AutoOffsetReset = AutoOffsetReset.Earliest,
								EnableAutoCommit = false
							}).Build());

							services.AddHostedService<RegisterConsumer>();
							services.AddHostedService<CourseConsumer>();

							services.AddDbContext<DataContext>(options =>
							{
								options.UseSqlServer(hostContext.Configuration.GetConnectionString("Db"));
							}, ServiceLifetime.Transient);

							services.AddMediatR(typeof(Program).Assembly);
						});
	}
}
