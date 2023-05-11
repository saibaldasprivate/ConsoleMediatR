using MediatR;

namespace ConsoleMediatR.Notifications.Order
{
    public class OrderProcessingPaymentNotification : INotification
    {
        public OrderProcessingPaymentNotification(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
