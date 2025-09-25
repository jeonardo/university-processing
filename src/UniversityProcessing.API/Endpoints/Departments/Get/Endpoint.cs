using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.API.Routing;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Filters;
using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.Departments.Get;

internal sealed class Endpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = GetType();
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization()
            .AddEndpointFilter<ValidationFilter<RequestDto>>();
    }

    private static async Task<ResponseDto> Handle(
        [AsParameters] RequestDto request,
        [FromServices] IEfRepository<Department> repository,
        CancellationToken cancellationToken)
    {
        var pagedList = await repository.TypedDbContext.ToPagedListAsync(
            request,
            x => x.FacultyId == request.FacultyId
                && (EF.Functions.Like(x.Name, $"%{request.Filter}%")
                    || EF.Functions.Like(x.ShortName, $"%{request.Filter}%")),
            x => new DepartmentDto(x.Id, x.Name, x.ShortName),
            null,null,
            cancellationToken);
        return new ResponseDto(pagedList);
    }
}
