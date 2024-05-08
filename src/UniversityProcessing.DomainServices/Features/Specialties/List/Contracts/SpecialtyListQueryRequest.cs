using MediatR;

namespace UniversityProcessing.DomainServices.Features.Specialties.List.Contracts;

public sealed record SpecialtyListQueryRequest(
    int PageNumber,
    int PageSize,
    string OrderBy,
    bool Desc) : IRequest<SpecialtyListQueryResponse>;