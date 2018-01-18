using System;

namespace NServiceBus.AuditFilter
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ExcludeFromAuditAttribute : Attribute
    {
    }
}