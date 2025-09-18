using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.API.Routing;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;

namespace UniversityProcessing.API.Endpoints.Registration.GetAvailableFaculties;

internal sealed class Endpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = GetType();
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type));
    }

    private static async Task<ResponseDto> Handle(
        [FromServices] IEfReadRepository<Faculty> repository,
        CancellationToken cancellationToken)
    {
        var faculties = await repository.TypedDbContext
            .AsNoTracking()
            .OrderBy(g => g.Name)
            .Select(x => new FacultyDto(x.Id, x.Name))
            .ToArrayAsync(cancellationToken: cancellationToken);

        return new ResponseDto(faculties);
    }
}
