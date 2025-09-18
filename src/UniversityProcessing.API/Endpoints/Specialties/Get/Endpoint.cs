using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.API.Routing;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.Specialties.Get;

internal sealed class Endpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(Endpoint);
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization();
    }

    private static async Task<ResponseDto> Handle(
        [AsParameters] RequestDto request,
        [FromServices] IEfReadRepository<Specialty> repository,
        CancellationToken cancellationToken)
    {
        var entities = await repository.TypedDbContext.ToPagedListAsync(
            request,
            x => x.DepartmentId == request.DepartmentId,
            x => new SpecialtyDto(x.Id, x.Name, x.ShortName, x.Code),
            null,
            cancellationToken);
        return new ResponseDto(entities);
    }
}
