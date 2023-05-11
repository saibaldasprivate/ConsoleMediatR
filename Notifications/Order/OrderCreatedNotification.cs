using MediatR;

namespace ConsoleMediatR.Notifications.Order
{
    public class OrderCreatedNotification : INotification
    {
        public OrderCreatedNotification(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
