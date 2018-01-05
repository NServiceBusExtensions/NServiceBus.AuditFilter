using System.Collections.Generic;

namespace NServiceBus.AuditFilter
{
    public delegate void Filter(object instance, IReadOnlyDictionary<string,string> headers, out bool includeInAudit);
}