using ConsoleMediatR.Notifications.Order;
using ConsoleMediatR.Notifications.Payment;
using MediatR;
using MediatR.NotificationPublishers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace ConsoleMediatR
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello to MediatR Application!");
            var hostBuilder = CreateHostBuilder(args);
            await hostBuilder.RunConsoleAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostingContext, services) =>
            {
                services.AddMediatR(configuration =>
                {
                    //Esta configuração é para paralelizar as notificações.
                    //A implementação defualt 'ForeachAwaitPublisher' roda sincrono
                    //e em caso de erro não executa os demais 
                    configuration.NotificationPublisher = new TaskWhenAllPublisher();
                    configuration.NotificationPublisherType = typeof(TaskWhenAllPublisher);

                    configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
                });

                services.AddSingleton<IHostedService, ConsoleApp>();
            });
    }

    public class ConsoleApp : IHostedService
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public ConsoleApp(ILogger<ConsoleApp> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Hello Notificações do MediatR");
            int choice = -1;
            while (choice != 0)
            {
                Console.WriteLine();
                Console.WriteLine("Please choose one option:");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Send Notification 'OrderCreated'.");
                Console.WriteLine("2. Send Notification 'OrderProcessingPaymentNotification'.");
                Console.WriteLine("3. Send Notification 'PaymentApprovedNotification'.");
                Console.WriteLine();
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    choice = -1;
                }

                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye...");
                        break;
                    case 1:
                        await _mediator.Publish(new OrderCreatedNotification(Guid.NewGuid()), cancellationToken);
                        break;
                    case 2:
                        await _mediator.Publish(new OrderProcessingPaymentNotification(Guid.NewGuid()), cancellationToken);
                        break;
                    case 3:
                        await _mediator.Publish(new PaymentApprovedNotification(Guid.NewGuid()), cancellationToken);
                        break;
                    default:
                        Console.WriteLine("Number invalid!");
                        break;
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}