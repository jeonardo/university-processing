using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Pagination;
using UniversityProcessing.GenericSubdomain.Routing;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.API.TODO.Endpoints.Employee.GetDepartments;

internal sealed class GetDepartments : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(GetDepartments);
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization();
    }

    private static async Task<GetDepartmentsResponseDto> Handle(
        [AsParameters] GetDepartmentsRequestDto request,
        [FromServices] IEfRepository<Department> repository,
        CancellationToken cancellationToken)
    {
        var validRequest = request.GetValidQueryParameters();

        var specification = new DepartmentListSpec(validRequest.PageNumber, validRequest.PageSize, validRequest.OrderBy, validRequest.Desc);
        var entities = await repository.ListAsync(specification, cancellationToken);

        var count = validRequest.IsFilterSet
            ? entities.Count
            : await repository.CountAsync(cancellationToken);

        return new GetDepartmentsResponseDto(new PagedList<DepartmentDto>(entities.Select(ToDto), count, validRequest.PageNumber, validRequest.PageSize));
    }

    private static DepartmentDto ToDto(Department input)
    {
        return new DepartmentDto(input.Id, input.Name, input.ShortName);
    }
}
