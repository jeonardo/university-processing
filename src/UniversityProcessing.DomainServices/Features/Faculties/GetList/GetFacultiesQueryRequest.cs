using MediatR;

namespace UniversityProcessing.DomainServices.Features.Faculties.GetList;

public sealed record GetFacultiesQueryRequest(
    int PageNumber,
    int PageSize,
    string OrderBy,
    bool Desc) : IRequest<GetFacultiesQueryResponse>;
