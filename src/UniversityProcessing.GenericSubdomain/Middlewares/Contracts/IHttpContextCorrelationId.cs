namespace UniversityProcessing.GenericSubdomain.Middlewares.Contracts;

public interface IHttpContextCorrelationId
{
    Guid Get();

    string GetAsString();

    void Set(Guid correlationId);

    void Set(string correlationId);
}
