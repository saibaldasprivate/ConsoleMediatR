using MediatR;

namespace ConsoleMediatR.Requests
{
    public class SimpleRequest : IRequest<SimpleResponse> { }
    public class SimpleResponse { }
    public class SimpleRequestHandler : IRequestHandler<SimpleRequest, SimpleResponse>
    {
        public Task<SimpleResponse> Handle(SimpleRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Handling request 'SimpleRequest'");
            return Task.FromResult(new SimpleResponse());
        }
    }
}
