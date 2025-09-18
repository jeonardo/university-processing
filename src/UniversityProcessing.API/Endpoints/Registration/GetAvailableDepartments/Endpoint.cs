using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.API.Routing;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Filters;

namespace UniversityProcessing.API.Endpoints.Registration.GetAvailableDepartments;

internal sealed class Endpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(Endpoint);
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .AddEndpointFilter<ValidationFilter<RequestDto>>();
    }

    private static async Task<ResponseDto> Handle(
        [AsParameters] RequestDto request,
        [FromServices] IEfReadRepository<Department> repository,
        CancellationToken cancellationToken)
    {
        var departments = await repository.TypedDbContext
            .AsNoTracking()
            .Where(x => x.FacultyId == request.FacultyId)
            .OrderBy(g => g.Name)
            .Select(x => new DepartmentDto(x.Id, x.Name))
            .ToArrayAsync(cancellationToken: cancellationToken);

        return new ResponseDto(departments);
    }
}
