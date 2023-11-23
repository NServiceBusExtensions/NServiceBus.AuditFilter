using NServiceBus.AuditFilter;

static class AttributeCache
{
    static ConcurrentDictionary<Type, bool?> cache = [];

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
        var includeInAuditAttribute = type.GetAttribute<IncludeInAuditAttribute>();
        var excludeFromAuditAttribute = type.GetAttribute<ExcludeFromAuditAttribute>();

        if (includeInAuditAttribute != null && excludeFromAuditAttribute != null)
        {
            throw new($"The message '{type.FullName}' contains both {nameof(IncludeInAuditAttribute)} and {nameof(ExcludeFromAuditAttribute)}.");
        }

        if (includeInAuditAttribute != null)
        {
            return true;
        }

        if (excludeFromAuditAttribute != null)
        {
            return false;
        }

        return null;
    }
}