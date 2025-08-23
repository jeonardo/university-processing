namespace UniversityProcessing.API.Middlewares.Contracts;

public sealed class HttpContextCorrelationId : IHttpContextCorrelationId
{
    private Guid? _value;

    public Guid Get()
    {
        return _value ?? Guid.NewGuid();
    }

    public string GetAsString()
    {
        return Get().ToString();
    }

    public void Set(Guid correlationId)
    {
        _value = correlationId;
    }

    public void Set(string correlationId)
    {
        if (Guid.TryParse(correlationId, out var guid))
        {
            _value = guid;
        }

        throw new ArgumentException(correlationId);
    }
}
