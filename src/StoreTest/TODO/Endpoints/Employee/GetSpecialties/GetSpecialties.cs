namespace StoreTest.TODO.Endpoints.Employee.GetSpecialties;

internal sealed class GetSpecialties : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(GetSpecialties);
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization();
    }

    private static async Task<GetSpecialtiesResponseDto> Handle(
        [AsParameters] GetSpecialtiesRequestDto request,
        [FromServices] IEfReadRepository<Specialty> repository,
        CancellationToken cancellationToken)
    {
        var entities = await repository.TypedDbContext.ToPagedListAsync(request, null, cancellationToken);
        return new GetSpecialtiesResponseDto(PagedListConverter.Convert(entities, ToDto));
    }

    private static SpecialtyDto ToDto(Specialty input)
    {
        return new SpecialtyDto(input.Id, input.Name, input.ShortName, input.Code);
    }
}
