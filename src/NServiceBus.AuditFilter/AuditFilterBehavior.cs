using System;
using System.Threading.Tasks;
using NServiceBus.Pipeline;

class AuditFilterBehavior :
    Behavior<IAuditContext>
{
    public override Task Invoke(IAuditContext context, Func<Task> next)
    {
        if (context.TryGetAuditContext(out var auditFilterContext))
        {
            if (!auditFilterContext.Audit)
            {
                return Task.FromResult(0);
            }
        }

        return next();
    }
}