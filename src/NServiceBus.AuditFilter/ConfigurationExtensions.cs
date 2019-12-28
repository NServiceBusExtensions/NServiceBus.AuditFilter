using System.Collections.Generic;
using NServiceBus.AuditFilter;

namespace NServiceBus
{
    /// <summary>
    /// Extensions to control what messages are audited.
    /// </summary>
    public static class AuditFilterConfigurationExtensions
    {
        public static void FilterAuditQueue(this EndpointConfiguration configuration, FilterResult defaultFilter)
        {
            Guard.AgainstNull(configuration, nameof(configuration));

            FilterResult Filter(object instance, IReadOnlyDictionary<string, string> headers)
            {
                return defaultFilter;
            }

            InnerFilter(configuration, Filter);
        }

        public static void FilterAuditQueue(this EndpointConfiguration configuration, Filter filter)
        {
            Guard.AgainstNull(configuration, nameof(configuration));
            Guard.AgainstNull(filter, nameof(filter));

            InnerFilter(configuration, filter);
        }

        static void InnerFilter(EndpointConfiguration configuration, Filter filter)
        {
            var pipeline = configuration.Pipeline;
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