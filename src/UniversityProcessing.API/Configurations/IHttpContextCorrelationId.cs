
namespace UniversityProcessing.API.Configurations
{
    public interface IHttpContextCorrelationId
    {
        Guid Value { get; }
        
        void Generate();

        void Set(Guid correlationId);

        void Set(string correlationId);
    }
}
