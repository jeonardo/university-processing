using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.API.Routing;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Filters;

namespace UniversityProcessing.API.Endpoints.Departments.Create;

internal sealed class Endpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(Endpoint);
        app
            .MapPost(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization()
            .AddEndpointFilter<ValidationFilter<RequestDto>>();
    }

    private static async Task<ResponseDto> Handle(
        [FromBody] RequestDto request,
        [FromServices] IEfRepository<Department> repository,
        CancellationToken cancellationToken)
    {
        var newEntity = Department.Create(request.Name, request.ShortName, request.FacultyId);

        await repository.AddAsync(newEntity, cancellationToken);

        return new ResponseDto(newEntity.Id);
    }
}
