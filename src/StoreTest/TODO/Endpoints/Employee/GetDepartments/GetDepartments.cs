namespace StoreTest.TODO.Endpoints.Employee.GetDepartments;

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
        var entities = await repository.TypedDbContext.ToPagedListAsync(request, null, cancellationToken);
        return new GetDepartmentsResponseDto(PagedListConverter.Convert(entities, ToDto));
    }

    private static DepartmentDto ToDto(Department input)
    {
        return new DepartmentDto(input.Id, input.Name, input.ShortName);
    }
}
