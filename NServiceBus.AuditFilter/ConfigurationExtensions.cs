using System.Collections.Generic;
using NServiceBus.AuditFilter;

namespace NServiceBus
{
    /// <summary>
    /// Extensions to control what messages are audited.
    /// </summary>
    public static class AuditFilterConfigurationExtensions
    {
        public static void UseAuditAttributeFilter(this EndpointConfiguration endpointConfiguration, bool defaultIncludeInAudit = true)
        {
            FilterResult Filter(object instance, IReadOnlyDictionary<string, string> headers)
            {
                if (defaultIncludeInAudit)
                {
                    return FilterResult.IncludeInAudit;
                }
                return FilterResult.ExcludeFromAudit;
            }

            UseAuditAttributeFilter(endpointConfiguration, Filter);
        }

        public static void UseAuditAttributeFilter(this EndpointConfiguration endpointConfiguration, Filter filter = null)
        {
            Guard.AgainstNull(endpointConfiguration, nameof(endpointConfiguration));

            if (filter == null)
            {
                filter = (instance, headers) => FilterResult.IncludeInAudit;
            }

            var pipeline = endpointConfiguration.Pipeline;
            pipeline.Register(
                behavior: typeof(AuditFilterBehavior),
                description: "Prevents marked messages from being forwarded to the audit queue");
            pipeline.Register(
                builder => new AuditRulesBehavior(filter),
                description: "Checks whether a message should be forwarded to the audit queue");
            pipeline.Register(
                behavior: typeof(AuditFilterContextBehavior),
                description: "Adds a shared state for the rules and filter behaviors");
        }
    }
}