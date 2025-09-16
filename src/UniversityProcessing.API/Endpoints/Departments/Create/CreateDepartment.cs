using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Filters;
using UniversityProcessing.Utils.Routing;

namespace UniversityProcessing.API.Endpoints.Departments.Create;

internal sealed class CreateDepartment : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(CreateDepartment);
        app
            .MapPost(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization()
            .AddEndpointFilter<ValidationFilter<CreateDepartmentRequestDto>>();
    }

    private static async Task<CreateDepartmentResponseDto> Handle(
        [FromBody] CreateDepartmentRequestDto request,
        [FromServices] IEfRepository<Department> repository,
        CancellationToken cancellationToken)
    {
        var newEntity = Department.Create(request.Name, request.ShortName, request.FacultyId);

        await repository.AddAsync(newEntity, cancellationToken);

        return new CreateDepartmentResponseDto(newEntity.Id);
    }
}
