using MediatR;

namespace UniversityProcessing.DomainServices.Features.Faculties.List.Contracts;

public sealed record FacultyListQueryRequest(
    int PageNumber,
    int PageSize,
    string OrderBy,
    bool Desc) : IRequest<FacultyListQueryResponse>;