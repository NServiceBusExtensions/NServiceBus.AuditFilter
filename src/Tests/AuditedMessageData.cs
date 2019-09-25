using System;
using System.Collections.Generic;

public class AuditedMessageData
{
    public Guid MessageId { get;  }
    public Type? MessageType { get;  }
    public string ProcessingEndpoint { get;  }
    public string OriginatingEndpoint { get; }
    public Dictionary<string, string> Metadata { get; }
    public string Body { get; }

    public AuditedMessageData(Guid messageId, string processingEndpoint, string originatingEndpoint, Type? messageType, Dictionary<string, string> metadata, string body)
    {
        MessageId = messageId;
        ProcessingEndpoint = processingEndpoint;
        OriginatingEndpoint = originatingEndpoint;
        MessageType = messageType;
        Metadata = metadata;
        Body = body;
    }
}