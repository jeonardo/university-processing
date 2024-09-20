using MediatR;

namespace UniversityProcessing.DomainServices.Features.Specialties.GetList;

public sealed record GetSpecialtiesQueryRequest(
    int PageNumber,
    int PageSize,
    string OrderBy,
    bool Desc) : IRequest<GetSpecialtiesQueryResponse>;
