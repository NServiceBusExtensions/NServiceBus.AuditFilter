using System;

namespace NServiceBus.AuditFilter
{
    [AttributeUsage(AttributeTargets.Class)]
    public class IncludeInAuditAttribute : Attribute
    {
    }
}