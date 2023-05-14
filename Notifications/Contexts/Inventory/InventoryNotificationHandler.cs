using ConsoleMediatR.Notifications.Order;
using ConsoleMediatR.Notifications.Payment;
using MediatR;

namespace ConsoleMediatR.Notifications.Contexts.Inventory
{
    internal class InventoryNotificationHandler : INotificationHandler<PaymentApprovedNotification>,
        INotificationHandler<OrderCreatedNotification>
    {
        public Task Handle(OrderCreatedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{nameof(InventoryNotificationHandler)}: Received a notification of the type: {nameof(OrderCreatedNotification)}");
            return Task.CompletedTask;
        }

        public Task Handle(PaymentApprovedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{nameof(InventoryNotificationHandler)}: Received a notification of the type: {nameof(PaymentApprovedNotification)}");
            return Task.CompletedTask;
        }

    }
}
