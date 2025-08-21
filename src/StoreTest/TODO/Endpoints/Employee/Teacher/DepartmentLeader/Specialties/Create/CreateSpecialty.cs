namespace StoreTest.TODO.Endpoints.Employee.Teacher.DepartmentLeader.Specialties.Create;

internal sealed class CreateSpecialty : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(CreateSpecialty);
        app
            .MapPost(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.Admin)))
            .AddEndpointFilter<ValidationFilter<CreateSpecialtyRequestDto>>();
    }

    private static async Task<CreateSpecialtyResponseDto> Handle(
        [FromBody] CreateSpecialtyRequestDto request,
        [FromServices] IEfRepository<Specialty> repository,
        CancellationToken cancellationToken)
    {
        var newEntity = Specialty.Create(request.Name, request.ShortName, request.Code, request.DepartmentId);

        await repository.AddAsync(newEntity, cancellationToken);

        return new CreateSpecialtyResponseDto(newEntity.Id);
    }
}
