using Microsoft.AspNetCore.Routing;

namespace UniversityProcessing.Utils.Endpoints;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}
