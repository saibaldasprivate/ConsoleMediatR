using MediatR;
using MediatR.Pipeline;

namespace ConsoleMediatR.Requests
{
    public class SimpleRequest : IRequest<SimpleResponse>  
    {
        public bool ShouldThrowException { get; set; }
    }

    public class SimpleResponse
    {
        public string? Anything { get; set; }
    }
   
    public class SimpleRequestHandler : IRequestHandler<SimpleRequest, SimpleResponse>
    {
        public Task<SimpleResponse> Handle(SimpleRequest request, CancellationToken cancellationToken)
        {
            if (request.ShouldThrowException)
            {
                throw new NotImplementedException();
            }

            Console.WriteLine("Handling request 'SimpleRequest'");
            return Task.FromResult(new SimpleResponse());
        }
    }

    public class SimpleRequestExceptionHandler : IRequestExceptionHandler<SimpleRequest, SimpleResponse>
    {
        public Task Handle(SimpleRequest request, Exception exception, RequestExceptionHandlerState<SimpleResponse> state, CancellationToken cancellationToken)
        {
            //here we can put some fallback logic like put in a queue to try proccess again or everything else
            //Do something
            Console.WriteLine("SimpleRequestExceptionHandler");
            state.SetHandled(new SimpleResponse());

            return Task.CompletedTask;
        }
    }
}
