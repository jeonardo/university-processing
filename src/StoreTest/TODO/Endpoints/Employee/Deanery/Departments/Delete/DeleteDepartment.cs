namespace StoreTest.TODO.Endpoints.Employee.Deanery.Departments.Delete;

internal sealed class DeleteDepartment : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(DeleteDepartment);
        app
            .MapDelete(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.Admin)))
            .AddEndpointFilter<ValidationFilter<DeleteDepartmentRequestDto>>();
    }

    private static async Task Handle(
        [AsParameters] DeleteDepartmentRequestDto request,
        [FromServices] IEfRepository<Department> repository,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdRequiredAsync(request.Id, cancellationToken);
        await repository.DeleteAsync(entity, cancellationToken);
    }
}
