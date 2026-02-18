// The state needs to be added early in the pipeline because anything added to the
// Extensions after the IIncomingPhysicalMessageContext is invisible to the IAuditContext.
class AuditFilterContextBehavior :
    Behavior<IIncomingPhysicalMessageContext>
{
    public override Task Invoke(IIncomingPhysicalMessageContext context, Func<Task> next)
    {
        context.AddAuditContext();
        return next();
    }
}
