using NServiceBus.Pipeline;

static class ContextHelper
{
    public static void AddAuditContext(this IIncomingPhysicalMessageContext context)
    {
        var auditFilterContext = new AuditFilterContext();
        context.Extensions.Set(auditFilterContext);
    }

    public static bool TryGetAuditContext(
        this IAuditContext context,
        out AuditFilterContext auditFilterContext) =>
        context.Extensions.TryGet(out auditFilterContext);

    public static AuditFilterContext GetAuditContext(this IIncomingLogicalMessageContext context) =>
        context.Extensions.Get<AuditFilterContext>();
}