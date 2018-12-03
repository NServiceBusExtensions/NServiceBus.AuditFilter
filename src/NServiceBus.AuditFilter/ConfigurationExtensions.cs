using System.Collections.Generic;
using NServiceBus.AuditFilter;

namespace NServiceBus
{
    /// <summary>
    /// Extensions to control what messages are audited.
    /// </summary>
    public static class AuditFilterConfigurationExtensions
    {
        public static void FilterAuditQueue(this EndpointConfiguration endpointConfiguration, FilterResult defaultFilter)
        {
            Guard.AgainstNull(endpointConfiguration, nameof(endpointConfiguration));

            FilterResult Filter(object instance, IReadOnlyDictionary<string, string> headers)
            {
                return defaultFilter;
            }

            InnerFilter(endpointConfiguration, Filter);
        }

        public static void FilterAuditQueue(this EndpointConfiguration endpointConfiguration, Filter filter)
        {
            Guard.AgainstNull(endpointConfiguration, nameof(endpointConfiguration));
            Guard.AgainstNull(filter, nameof(filter));

            InnerFilter(endpointConfiguration, filter);
        }

        static void InnerFilter(EndpointConfiguration endpointConfiguration, Filter filter)
        {
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