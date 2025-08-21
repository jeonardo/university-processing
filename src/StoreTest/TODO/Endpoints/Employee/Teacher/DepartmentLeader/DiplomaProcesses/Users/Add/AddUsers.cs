namespace StoreTest.TODO.Endpoints.Employee.Teacher.DepartmentLeader.DiplomaProcesses.Users.Add;

internal sealed class AddUsers : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(AddUsers);
        app
            .MapPost(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.Admin)))
            .AddEndpointFilter<ValidationFilter<AddUsersRequestDto>>();
    }

    private static async Task Handle(
        [FromBody] AddUsersRequestDto request,
        [FromServices] IEfRepository<DiplomaProcess> repository,
        [FromServices] IEfRepository<User> userRepository,
        [FromServices] UserManager<User> userManager,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
