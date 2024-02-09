namespace UniversityProcessing.API.Configurations
{
    public class HttpContextCorrelationId : IHttpContextCorrelationId
    {
        public Guid Value { get; private set; }

        public void Generate()
        {
            Value = Guid.NewGuid();
        }

        public void Set(Guid correlationId)
        {
            Value = correlationId;
        }

        public void Set(string correlationId)
        {
            Value = new Guid(correlationId);
        }
    }
}
