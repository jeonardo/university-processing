using System;

namespace UniversityProcessing.Domain.API;

/// <summary>
/// Base class used by API requests
/// </summary>
public abstract record BaseMessage
{
    /// <summary>
    /// Unique Identifier used by logging
    /// </summary>
    public BaseMessage()
    {
        CorrelationId = Guid.NewGuid();
    }

    /// <summary>
    /// Unique Identifier used by logging
    /// </summary>
    protected BaseMessage(Guid correlationId)
    {
        CorrelationId = correlationId;
    }

    public Guid CorrelationId { get; private init; }
}
