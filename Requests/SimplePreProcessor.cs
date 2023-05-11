using MediatR.Pipeline;

namespace ConsoleMediatR.Requests
{
    public class SimplePreProcessor : IRequestPreProcessor<SimpleRequest>
    {
        public Task Process(SimpleRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Pre processing request 'SimpleRequest'");
            return Task.CompletedTask;
        }
    }
}
