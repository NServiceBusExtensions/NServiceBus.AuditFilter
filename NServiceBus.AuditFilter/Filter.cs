﻿using System.Collections.Generic;

namespace NServiceBus.AuditFilter
{
    public delegate FilterResult Filter(object instance, IReadOnlyDictionary<string,string> headers);
}