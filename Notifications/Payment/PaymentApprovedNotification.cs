using MediatR;

namespace ConsoleMediatR.Notifications.Payment
{
    public class PaymentApprovedNotification : INotification
    {
        public PaymentApprovedNotification(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
