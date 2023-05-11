using ConsoleMediatR.Notifications.Order;
using MediatR;

namespace ConsoleMediatR.Contexts.Delivery
{
    internal class DeliveryNotificationHandler : INotificationHandler<OrderSuccesfullyCompletedNotification>
    {
        public Task Handle(OrderSuccesfullyCompletedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine();
            Console.WriteLine($"{nameof(DeliveryNotificationHandler)}: Received a notification of the type:: {nameof(OrderSuccesfullyCompletedNotification)}");
            Console.WriteLine("Preparing items.");
            Console.WriteLine();

            return Task.CompletedTask;
        }
    }
}
