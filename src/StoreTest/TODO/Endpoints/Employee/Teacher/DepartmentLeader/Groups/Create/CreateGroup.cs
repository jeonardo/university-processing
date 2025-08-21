using System.Text.RegularExpressions;

namespace StoreTest.TODO.Endpoints.Employee.Teacher.DepartmentLeader.Groups.Create;

internal sealed class CreateGroup : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(CreateGroup);
        app
            .MapPost(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.Admin)))
            .AddEndpointFilter<ValidationFilter<CreateGroupRequestDto>>();
    }

    private static async Task<CreateGroupResponseDto> Handle(
        [FromBody] CreateGroupRequestDto request,
        [FromServices] IEfRepository<Group> repository,
        CancellationToken cancellationToken)
    {
        var newEntity = Group.Create(request.GroupNumber, request.StartDate, request.EndDate, request.SpecialtyId);

        await repository.AddAsync(newEntity, cancellationToken);

        return new CreateGroupResponseDto(newEntity.Id);
    }
}
