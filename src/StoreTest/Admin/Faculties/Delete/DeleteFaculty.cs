namespace StoreTest.Admin.Faculties.Delete;

internal sealed class DeleteFaculty : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(DeleteFaculty);
        app
            .MapDelete(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.Admin)))
            .AddEndpointFilter<ValidationFilter<DeleteFacultyRequestDto>>();
    }

    private static async Task Handle(
        [AsParameters] DeleteFacultyRequestDto request,
        [FromServices] IEfRepository<Faculty> repository,
        CancellationToken cancellationToken)
    {
        var record = await repository.GetByIdRequiredAsync(request.Id, cancellationToken);

        if (record.Departments.Any())
        {
            throw new ConflictException("Faculty contains departments");
        }

        await repository.DeleteAsync(record, cancellationToken);
    }
}
