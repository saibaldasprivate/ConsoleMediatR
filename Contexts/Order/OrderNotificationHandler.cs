using ConsoleMediatR.Notifications.Order;
using ConsoleMediatR.Notifications.Payment;
using MediatR;

namespace ConsoleMediatR.Contexts.Order
{
    public class OrderNotificationHandler : 
        INotificationHandler<OrderProcessingPaymentNotification>
        , INotificationHandler<PaymentApprovedNotification>
    {
        private readonly IMediator _mediator;

        public OrderNotificationHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task Handle(OrderProcessingPaymentNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{nameof(OrderNotificationHandler)}: Received a notification of the type: {nameof(OrderProcessingPaymentNotification)}");
            return Task.CompletedTask;
        }

        public async Task Handle(PaymentApprovedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{nameof(OrderNotificationHandler)}: Received a notification of the type: {nameof(PaymentApprovedNotification)}");
            Console.WriteLine($"{nameof(OrderNotificationHandler)}: Sending a notification of the type: {nameof(OrderSuccesfullyCompletedNotification)}");
            await _mediator.Publish<OrderSuccesfullyCompletedNotification>(new(notification.Id));
        }
    }
}
