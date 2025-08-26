using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Filters;
using UniversityProcessing.Utils.Pagination;
using UniversityProcessing.Utils.Routing;

namespace UniversityProcessing.API.Endpoints.Users.GetTeachers;

internal sealed class GetTeachers : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(GetTeachers);
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.Deanery), nameof(UserRoleType.Teacher), nameof(UserRoleType.Student)))
            .AddEndpointFilter<ValidationFilter<GetTeachersRequestDto>>();
    }

    private static async Task<GetTeachersResponseDto> Handle(
        [AsParameters] GetTeachersRequestDto request,
        [FromServices] IEfReadRepository<Teacher> repository,
        CancellationToken cancellationToken)
    {
        var pagedList = await repository.TypedDbContext.ToPagedListAsync(
            request,
            x => EF.Functions.Like(x.FullName, $"%{request.Filter}%"),
            x => new TeacherDto(x.Id, x.FirstName, x.LastName, x.MiddleName, x.Approved, x.Blocked, x.UniversityPosition.Name),
            x => x.Include(deanery => deanery.UniversityPosition),
            cancellationToken);
        return new GetTeachersResponseDto(pagedList);
    }
}
