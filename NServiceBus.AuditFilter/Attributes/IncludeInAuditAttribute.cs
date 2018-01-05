namespace NServiceBus.AuditFilter
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    public class IncludeInAuditAttribute : Attribute
    {
    }
}
