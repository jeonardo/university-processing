using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Routing;

namespace UniversityProcessing.API.Endpoints.Auth.Registration.GetAvailableFaculties;

internal sealed class GetAvailableFaculties : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(GetAvailableFaculties);
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type));
    }

    private static async Task<GetAvailableFacultiesResponseDto> Handle(
        [FromServices] IEfReadRepository<Faculty> repository,
        CancellationToken cancellationToken)
    {
        var faculties = await repository.TypedDbContext
            .AsNoTracking()
            .OrderBy(g => g.Name)
            .Select(x => new FacultyDto(x.Id, x.Name))
            .ToArrayAsync(cancellationToken: cancellationToken);

        return new GetAvailableFacultiesResponseDto(faculties);
    }
}
