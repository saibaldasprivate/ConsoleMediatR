using MediatR;

namespace ConsoleMediatR.Streams
{
    public class SimpleStreamRequestHandler : IStreamRequestHandler<SimpleStreamRequest, SimpleStreamResponse>
    {
        private int _count;
        public async IAsyncEnumerable<SimpleStreamResponse> Handle(SimpleStreamRequest request, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(1000, cancellationToken);
                _count++;

                yield return new SimpleStreamResponse(request.Id, _count);
            }
        }
    }
}
