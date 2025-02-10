using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Filters;
using UniversityProcessing.GenericSubdomain.Routing;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.API.Endpoints.Employee.Teacher.DepartmentLeader.DiplomaProcesses.Create;

internal sealed class CreateDiplomaProcess : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(CreateDiplomaProcess);
        app
            .MapPost(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.Admin)))
            .AddEndpointFilter<ValidationFilter<CreateDiplomaProcessRequestDto>>();
    }

    private static async Task<CreateDiplomaProcessResponseDto> Handle(
        [FromBody] CreateDiplomaProcessRequestDto request,
        [FromServices] IEfRepository<DiplomaProcess> repository,
        CancellationToken cancellationToken)
    {
        var newEntity = DiplomaProcess.Create(request.Name, request.PeriodId);

        await repository.AddAsync(newEntity, cancellationToken);

        return new CreateDiplomaProcessResponseDto(newEntity.Id);
    }
}
