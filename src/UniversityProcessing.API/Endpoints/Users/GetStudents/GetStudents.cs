using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Filters;
using UniversityProcessing.Utils.Pagination;
using UniversityProcessing.Utils.Routing;

namespace UniversityProcessing.API.Endpoints.Users.GetStudents;

internal sealed class GetStudents : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(GetStudents);
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.Deanery), nameof(UserRoleType.Teacher)))
            .AddEndpointFilter<ValidationFilter<GetStudentsRequestDto>>();
    }

    private static async Task<GetStudentsResponseDto> Handle(
        [AsParameters] GetStudentsRequestDto request,
        [FromServices] IEfReadRepository<Student> repository,
        CancellationToken cancellationToken)
    {
        var pagedList = await repository.TypedDbContext.ToPagedListAsync(
            request,
            x => EF.Functions.Like(x.FullName, $"%{request.Filter}%"),
            x => new StudentDto(x.Id, x.FirstName, x.LastName, x.MiddleName, x.Approved, x.Blocked),
            null,
            cancellationToken);
        return new GetStudentsResponseDto(pagedList);
    }
}
