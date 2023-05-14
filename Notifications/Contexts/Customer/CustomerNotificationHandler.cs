using ConsoleMediatR.Notifications.Order;
using MediatR;

namespace ConsoleMediatR.Notifications.Contexts.Customer
{
    internal class CustomerNotificationHandler : INotificationHandler<OrderProcessingPaymentNotification>
    {
        public Task Handle(OrderProcessingPaymentNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{nameof(CustomerNotificationHandler)}: Received a notification of the type: {nameof(OrderProcessingPaymentNotification)}");
            return Task.CompletedTask;
        }
    }
}
