using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Pagination;
using UniversityProcessing.GenericSubdomain.Routing;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.API.TODO.Endpoints.Periods.Get;

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
        var validRequest = request.GetValidQueryParameters();

        var specification = new GetPeriodsSpec(validRequest.PageNumber, validRequest.PageSize);
        var entities = await repository.ListAsync(specification, cancellationToken);

        var count = validRequest.IsFilterSet
            ? entities.Count
            : await repository.CountAsync(cancellationToken);

        return new GetPeriodsResponseDto(new PagedList<PeriodDto>(entities.Select(ToDto), count, validRequest.PageNumber, validRequest.PageSize));
    }

    private static PeriodDto ToDto(Period input)
    {
        return new PeriodDto(input.Id, input.From, input.To, input.Comments);
    }

    private sealed class GetPeriodsSpec(int pageNumber, int pageSize)
        : BaseListSpec<Period>(pageNumber, pageSize, ORDER_BY_PROPERTY, true)
    {
        protected override string[] AvailableProperties => [ORDER_BY_PROPERTY];
    }
}
