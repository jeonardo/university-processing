namespace StoreTest.TODO.Endpoints.Admin.Periods.Delete;

internal sealed class DeletePeriod : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(DeletePeriod);
        app
            .MapDelete(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.Admin)))
            .AddEndpointFilter<ValidationFilter<DeletePeriodRequestDto>>();
    }

    private static async Task Handle(
        [AsParameters] DeletePeriodRequestDto request,
        [FromServices] IEfRepository<Period> repository,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdRequiredAsync(request.Id, cancellationToken);

        if (entity.DiplomaProcesses.Count != 0)
        {
            throw new ConflictException("Period contains diploma processes");
        }

        await repository.DeleteAsync(entity, cancellationToken);
    }
}
