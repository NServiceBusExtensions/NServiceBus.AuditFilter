using System;
using System.Collections.Concurrent;
using NServiceBus.AuditFilter;

static class AttributeCache
{
    static ConcurrentDictionary<Type, bool?> cache = new ConcurrentDictionary<Type, bool?>();

    public static bool TryGetIncludeInAudit(Type type, out bool includeInAudit)
    {
        var tryIncludeInAudit = cache.GetOrAdd(type, InnerTryGetIncludeInAudit);
        if (tryIncludeInAudit.HasValue)
        {
            includeInAudit = tryIncludeInAudit.Value;
            return true;
        }

        includeInAudit = false;
        return false;
    }

    static bool? InnerTryGetIncludeInAudit(Type type)
    {
        if (type.GetAttribute<IncludeInAuditAttribute>() != null)
        {
            return true;
        }

        if (type.GetAttribute<ExcludeFromAuditAttribute>() != null)
        {
            return false;
        }

        return null;
    }
}