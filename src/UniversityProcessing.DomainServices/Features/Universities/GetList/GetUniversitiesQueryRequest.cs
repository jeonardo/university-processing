using MediatR;

namespace UniversityProcessing.DomainServices.Features.Universities.GetList;

public sealed record GetUniversitiesQueryRequest(
    int PageNumber,
    int PageSize,
    string OrderBy,
    bool Desc) : IRequest<GetUniversitiesQueryResponse>;
