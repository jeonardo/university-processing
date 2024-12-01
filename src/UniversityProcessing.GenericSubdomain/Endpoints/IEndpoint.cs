using Microsoft.AspNetCore.Routing;

namespace UniversityProcessing.GenericSubdomain.Endpoints;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}
