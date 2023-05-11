using MediatR.Pipeline;

namespace ConsoleMediatR.Requests
{
    public class SimpleRequestPostProcessor : IRequestPostProcessor<SimpleRequest, SimpleResponse>
    {
        public Task Process(SimpleRequest request, SimpleResponse response, CancellationToken cancellationToken)
        {
            Console.WriteLine("Post processing request 'SimpleRequest'");
            return Task.CompletedTask;
        }
    }
}
