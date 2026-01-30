public class Usage
{
    static void FilterAuditByAttribute(EndpointConfiguration configuration)
    {
        #region DefaultIncludeInAudit

        configuration.FilterAuditQueue(FilterResult.IncludeInAudit);

        #endregion

        #region DefaultExcludeFromAudit

        configuration.FilterAuditQueue(FilterResult.ExcludeFromAudit);

        #endregion

        #region FilterAuditByDelegate

        configuration.FilterAuditQueue(
            filter: (instance, _) =>
            {
                if (instance is MyMessage)
                {
                    return FilterResult.ExcludeFromAudit;
                }

                return FilterResult.IncludeInAudit;
            });

        #endregion
    }

    public class MyMessage;
}