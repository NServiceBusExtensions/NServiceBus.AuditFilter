using NServiceBus;
using NServiceBus.AuditFilter;

[ExcludeFromAudit]
public class DoNotAuditThisMessage : IMessage
{
    public string Content { get; set; }
}