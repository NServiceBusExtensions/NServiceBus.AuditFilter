using System;
using System.Threading.Tasks;
using NServiceBus;

class MyHandler :
    IHandleMessages<AuditThisMessage>,
    IHandleMessages<DoNotAuditThisMessage>
{
    public Task Handle(AuditThisMessage message, IMessageHandlerContext context)
    {
        Console.WriteLine("Hello from MyHandler. AuditThisMessage");
        return Task.FromResult(0);
    }

    public Task Handle(DoNotAuditThisMessage message, IMessageHandlerContext context)
    {
        Console.WriteLine("Hello from MyHandler. DoNotAuditThisMessage");
        return Task.FromResult(0);
    }
}