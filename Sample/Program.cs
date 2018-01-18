using System;
using System.Threading.Tasks;
using NServiceBus;

class Program
{
    static async Task Main()
    {
        var configuration = new EndpointConfiguration("AuditFilterSample");
        configuration.UsePersistence<InMemoryPersistence>();
        configuration.UseTransport<LearningTransport>();
        configuration.AuditProcessedMessagesTo("audit");
        configuration.UseAuditAttributeFilter();

        var endpoint = await Endpoint.Start(configuration);

        await endpoint.SendLocal(new AuditThisMessage());

        await endpoint.SendLocal(new DoNotAuditThisMessage());

        Console.WriteLine("Press any key to stop program");
        Console.Read();
        await endpoint.Stop();
    }
}