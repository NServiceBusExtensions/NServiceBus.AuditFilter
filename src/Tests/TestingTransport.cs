using Newtonsoft.Json;
using NServiceBus;

public class TestingTransport
{
    string fullPath;
    string auditPath;
    int endpointInstanceCount;

    public TestingTransport([CallerMemberName] string key = "")
    {
        fullPath = Path.GetFullPath(key);
        auditPath = Path.Combine(fullPath, "audit");
        if (Directory.Exists(fullPath))
        {
            Directory.Delete(fullPath, true);
        }
    }

    public void ApplyToEndpoint(EndpointConfiguration configuration)
    {
        endpointInstanceCount++;
        var transport = configuration.UseTransport<LearningTransport>();
        configuration.AuditProcessedMessagesTo("audit");
        transport.StorageDirectory(fullPath);
    }

    public async Task<List<AuditedMessageData>> GetProcessedMessages(params IEndpointInstance[] endpointInstances)
    {
        if (endpointInstances.Length != endpointInstanceCount)
        {
            throw new();
        }
        await Task.Delay(100);
        var breaker = 0;
        while (true)
        {
            await Task.Delay(50);
            if (!AreMessagesPending())
            {
                break;
            }

            breaker++;
            if (breaker > 100)
            {
                throw new("Breaker hit before all pending messages were flushed.");
            }
        }

        await Task.WhenAll(endpointInstances.Select(x => x.Stop()));

        return GetMessages().ToList();
    }

    IEnumerable<AuditedMessageData> GetMessages()
    {
        if (!Directory.Exists(auditPath))
        {
            yield break;
        }
        foreach (var metadataFile in Directory.EnumerateFiles(auditPath, "*.metadata.txt"))
        {
            var metadata = DeserializeMetadata(metadataFile);
            yield return new(
                messageId: new(metadata[Headers.MessageId]),
                processingEndpoint: metadata[Headers.ProcessingEndpoint],
                originatingEndpoint: metadata[Headers.OriginatingEndpoint],
                messageType: GetMessageType(metadata),
                metadata: metadata,
                body: GetBody(metadataFile)
            );
        }
    }

    string GetBody(string metadataFile)
    {
        var fileId = Path.GetFileName(metadataFile).Replace(".metadata.txt", "");
        var bodyPath = Path.Combine(auditPath, ".bodies", $"{fileId}.body.txt");
        return File.ReadAllText(bodyPath);
    }

    static Type? GetMessageType(Dictionary<string, string> metadata)
    {
        if (metadata.TryGetValue(Headers.EnclosedMessageTypes, out var messageTypeName))
        {
            return Type.GetType(messageTypeName, true);
        }

        return null;
    }

    static Dictionary<string, string> DeserializeMetadata(string messageMetadata) =>
        JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(messageMetadata))!;

    bool AreMessagesPending() =>
        EndpointDirectories().Any(HasPendingMessages);

    static bool HasPendingMessages(string endpointDirectory) =>
        Directory.EnumerateDirectories(endpointDirectory, ".pending")
            .Any(pending => Directory.EnumerateFiles(pending).Any());

    IEnumerable<string> EndpointDirectories() =>
        Directory.EnumerateDirectories(fullPath);
}