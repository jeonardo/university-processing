using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.API.Routing;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Filters;

namespace UniversityProcessing.API.Endpoints.Registration.GetAvailableGroups;

internal sealed class Endpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = GetType();
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .AddEndpointFilter<ValidationFilter<RequestDto>>();
    }

    private static async Task<ResponseDto> Handle(
        [AsParameters] RequestDto request,
        [FromServices] IEfReadRepository<Group> repository,
        CancellationToken cancellationToken)
    {
        var groups = await repository.TypedDbContext
            .AsNoTracking()
            .Where(g => EF.Functions.Like(g.Number, $"%{request.Number}%"))
            .OrderBy(g => g.Number)
            .Take(20)
            .Select(g => g.Number)
            .ToArrayAsync(cancellationToken: cancellationToken);

        return new ResponseDto(groups);
    }
}
