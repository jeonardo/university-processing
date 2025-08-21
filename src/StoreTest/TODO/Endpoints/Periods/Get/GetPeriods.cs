namespace StoreTest.TODO.Endpoints.Periods.Get;

internal sealed class GetPeriods : IEndpoint
{
    private const string ORDER_BY_PROPERTY = "from";

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(GetPeriods);
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization();
    }

    private static async Task<GetPeriodsResponseDto> Handle(
        [AsParameters] GetPeriodsRequestDto request,
        [FromServices] IEfRepository<Period> repository,
        CancellationToken cancellationToken)
    {
        var entities = await repository.TypedDbContext.ToPagedListAsync(request, null, cancellationToken);
        return new GetPeriodsResponseDto(PagedListConverter.Convert(entities, ToDto));
    }

    private static PeriodDto ToDto(Period input)
    {
        return new PeriodDto(input.Id, input.From, input.To, input.Comments);
    }
}
