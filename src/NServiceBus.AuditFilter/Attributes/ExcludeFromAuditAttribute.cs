namespace NServiceBus.AuditFilter;

/// <summary>
/// Used to exclude a message from being sent to the Audit queue.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public sealed class ExcludeFromAuditAttribute :
    Attribute
{
}