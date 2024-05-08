using MediatR;

namespace UniversityProcessing.DomainServices.Features.Departments.List.Contracts;

public sealed record DepartmentListQueryRequest(
    int PageNumber,
    int PageSize,
    string OrderBy,
    bool Desc) : IRequest<DepartmentListQueryResponse>;