using MediatR;

namespace ConsoleMediatR.Notifications.Order
{
    public class OrderSuccesfullyCompletedNotification : INotification
    {
        public OrderSuccesfullyCompletedNotification(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
