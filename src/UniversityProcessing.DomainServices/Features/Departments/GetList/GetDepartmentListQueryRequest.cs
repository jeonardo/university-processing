using MediatR;

namespace UniversityProcessing.DomainServices.Features.Departments.GetList;

public sealed record GetDepartmentListQueryRequest(
    int PageNumber,
    int PageSize,
    string OrderBy,
    bool Desc) : IRequest<GetDepartmentListQueryResponse>;
