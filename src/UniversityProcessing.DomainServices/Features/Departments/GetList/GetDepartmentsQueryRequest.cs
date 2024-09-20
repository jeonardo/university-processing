using MediatR;

namespace UniversityProcessing.DomainServices.Features.Departments.GetList;

public sealed record GetDepartmentsQueryRequest(
    int PageNumber,
    int PageSize,
    string OrderBy,
    bool Desc) : IRequest<GetDepartmentsQueryResponse>;
