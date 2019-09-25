using NServiceBus;
using NServiceBus.AuditFilter;

[IncludeInAudit]
public class AuditThisMessage :
    IMessage
{
    public string? Content { get; set; }
}