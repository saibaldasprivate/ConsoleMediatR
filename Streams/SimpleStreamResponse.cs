namespace ConsoleMediatR.Streams
{
    public class SimpleStreamResponse
    {
        public SimpleStreamResponse(Guid requestId, int count)
        {
            RequestId = requestId;
            Count = count;
        }

        public Guid RequestId { get; set; }
        public int Count { get; set; }
    }
}
