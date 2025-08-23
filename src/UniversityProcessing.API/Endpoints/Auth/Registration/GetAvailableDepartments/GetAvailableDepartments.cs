using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Filters;
using UniversityProcessing.Utils.Routing;

namespace UniversityProcessing.API.Endpoints.Auth.Registration.GetAvailableDepartments;

internal sealed class GetAvailableDepartments : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(GetAvailableDepartments);
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .AddEndpointFilter<ValidationFilter<GetAvailableDepartmentsRequestDto>>();
    }

    private static async Task<GetAvailableDepartmentsResponseDto> Handle(
        [AsParameters] GetAvailableDepartmentsRequestDto request,
        [FromServices] IEfReadRepository<Department> repository,
        CancellationToken cancellationToken)
    {
        var departments = await repository.TypedDbContext
            .AsNoTracking()
            .Where(x => x.FacultyId == request.FacultyId)
            .OrderBy(g => g.Name)
            .Select(x => new DepartmentDto(x.Id, x.Name))
            .ToArrayAsync(cancellationToken: cancellationToken);

        return new GetAvailableDepartmentsResponseDto(departments);
    }
}
