using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Namespace;
using UniversityProcessing.GenericSubdomain.Pagination;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.API.Endpoints.Common.GetDepartments;

internal sealed class GetDepartments : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app
            .MapGet(NamespaceService.GetEndpointRoute(typeof(GetDepartments)), Handle)
            .RequireAuthorization();
    }

    private static async Task<GetDepartmentsResponseDto> Handle(
        [AsParameters] GetDepartmentsRequestDto request,
        [FromServices] IEfRepository<Department> repository,
        CancellationToken cancellationToken)
    {
        var count = await repository.CountAsync(cancellationToken);

        var specification = new DepartmentListSpec(request.PageNumber, request.PageSize, request.OrderBy, request.Desc);
        var entities = await repository.ListAsync(specification, cancellationToken);

        return new GetDepartmentsResponseDto(new PagedList<DepartmentDto>(entities.Select(ToDto), count, request.PageNumber, request.PageSize));
    }

    private static DepartmentDto ToDto(Department input)
    {
        return new DepartmentDto(input.Id, input.Name, input.ShortName);
    }
}
