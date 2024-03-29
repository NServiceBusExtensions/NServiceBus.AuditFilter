﻿namespace NServiceBus.AuditFilter;

/// <summary>
/// Used to include a message in being sent to the Audit queue.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public sealed class IncludeInAuditAttribute :
    Attribute;