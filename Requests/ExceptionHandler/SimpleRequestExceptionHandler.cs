using MediatR.Pipeline;

namespace ConsoleMediatR.Requests.ExceptionHandler
{
    public class SimpleRequestExceptionHandler : IRequestExceptionHandler<SimpleExceptionRequest, SimpleExceptionResponse>
    {
        public Task Handle(SimpleExceptionRequest request, Exception exception, RequestExceptionHandlerState<SimpleExceptionResponse> state, CancellationToken cancellationToken)
        {
            Console.WriteLine("SimpleRequestExceptionHandler");
            state.SetHandled(new SimpleExceptionResponse());

            return Task.CompletedTask;
        }
    }
}
