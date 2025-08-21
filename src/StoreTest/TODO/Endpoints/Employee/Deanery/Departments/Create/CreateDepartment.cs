using StoreTest.TODO.Endpoints.Employee.Deanery.Departments.Delete;

namespace StoreTest.TODO.Endpoints.Employee.Deanery.Departments.Create;

internal sealed class CreateDepartment : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(CreateDepartment);
        app
            .MapPost(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.Admin)))
            .AddEndpointFilter<ValidationFilter<DeleteDepartmentRequestDto>>();
    }

    private static async Task<CreateDepartmentResponseDto> Handle(
        [FromBody] CreateDepartmentRequestDto request,
        [FromServices] IEfRepository<Department> repository,
        CancellationToken cancellationToken)
    {
        var newEntity = Department.Create(request.Name, request.ShortName, request.FacultyId);

        await repository.AddAsync(newEntity, cancellationToken);

        return new CreateDepartmentResponseDto(newEntity.Id);
    }
}
