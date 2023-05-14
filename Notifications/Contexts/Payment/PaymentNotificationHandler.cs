using ConsoleMediatR.Notifications.Order;
using MediatR;

namespace ConsoleMediatR.Notifications.Contexts.Payment
{
    internal class PaymentNotificationHandler : INotificationHandler<OrderProcessingPaymentNotification>
    {
        public Task Handle(OrderProcessingPaymentNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{nameof(PaymentNotificationHandler)}: Received a notification of the type: {nameof(OrderProcessingPaymentNotification)}");
            return Task.CompletedTask;
        }
    }
}
