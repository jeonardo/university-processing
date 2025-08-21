namespace StoreTest.Admin.Faculties.SetFacultyHead;

internal sealed class SetFacultyHead : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(SetFacultyHead);
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.Admin)))
            .AddEndpointFilter<ValidationFilter<SetFacultyHeadRequestDto>>();
    }

    private static async Task Handle(
        [AsParameters] SetFacultyHeadRequestDto request,
        [FromServices] IEfRepository<Faculty> repository,
        CancellationToken cancellationToken)
    {
        var faculty = await repository.GetByIdRequiredAsync(request.FacultyId, cancellationToken);

        faculty.SetHead(request.UserId);

        await repository.UpdateAsync(faculty, cancellationToken);
    }
}
