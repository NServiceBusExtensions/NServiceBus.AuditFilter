public class AuditedMessageData(
    Guid messageId,
    string processingEndpoint,
    string originatingEndpoint,
    Type? messageType,
    Dictionary<string, string> metadata,
    string body)
{
    public Guid MessageId { get;  } = messageId;
    public Type? MessageType { get;  } = messageType;
    public string ProcessingEndpoint { get;  } = processingEndpoint;
    public string OriginatingEndpoint { get; } = originatingEndpoint;
    public Dictionary<string, string> Metadata { get; } = metadata;
    public string Body { get; } = body;
}