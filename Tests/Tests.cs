using System.IO;
using System.Threading.Tasks;
using NServiceBus;
using Xunit;

public class Tests
{
    [Fact]
    public async Task Foo()
    {
        var auditQueuePath = Path.GetFullPath("../../../../.learningtransport/audit");
        var configuration = new EndpointConfiguration("AuditFilterSample");
        configuration.UsePersistence<InMemoryPersistence>();
        configuration.UseTransport<LearningTransport>();
        configuration.AuditProcessedMessagesTo("audit");
        configuration.UseAuditAttributeFilter();

        var endpoint = await Endpoint.Start(configuration);

        await endpoint.SendLocal(new AuditThisMessage());

        await endpoint.SendLocal(new DoNotAuditThisMessage());

        await endpoint.Stop();
    }

}