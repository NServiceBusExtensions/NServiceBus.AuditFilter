using System;
using System.Threading.Tasks;
using NServiceBus.AuditFilter;
using NServiceBus.Pipeline;

class AuditRulesBehavior : Behavior<IIncomingLogicalMessageContext>
{
    Filter filter;

    public AuditRulesBehavior(Filter filter)
    {
        this.filter = filter;
    }

    public override Task Invoke(IIncomingLogicalMessageContext context, Func<Task> next)
    {
        var instance = context.Message.Instance;
        if (instance != null)
        {
            var auditFilterContext = context.GetAuditContext();
            auditFilterContext.Audit = ShouldIncludeInAudit(context);
        }

        return next();
    }

    bool ShouldIncludeInAudit(IIncomingLogicalMessageContext context)
    {
        var messageType = context.Message.Instance.GetType();
        if (AttributeCache.TryGetIncludeInAudit(messageType, out var includeInAudit))
        {
            return includeInAudit;
        }

        var filterResult = filter(context.Message.Instance, context.MessageHeaders);
        if (filterResult == FilterResult.IncludeInAudit)
        {
            return true;
        }
        return false;
    }
}