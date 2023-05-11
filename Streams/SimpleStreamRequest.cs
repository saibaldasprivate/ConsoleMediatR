using MediatR;

namespace ConsoleMediatR.Streams
{
    public class SimpleStreamRequest : IStreamRequest<SimpleStreamResponse> 
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
