using MediatR.Pipeline;

namespace ConsoleMediatR.Requests.ExceptionAction
{
    public class SimpleRequestExceptionAction : IRequestExceptionAction<SimpleExceptionActionRequest>
    {
        public Task Execute(SimpleExceptionActionRequest request, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine("Doing something before the exception is thrown.");
            return Task.CompletedTask;
        }
    }
}
