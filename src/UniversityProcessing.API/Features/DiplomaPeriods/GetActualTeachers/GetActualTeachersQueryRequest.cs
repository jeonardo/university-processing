using MediatR;

namespace UniversityProcessing.API.Features.DiplomaPeriods.GetActualTeachers;

public sealed record GetActualTeachersQueryRequest(
    int PageNumber,
    int PageSize,
    string OrderBy,
    bool Desc) : IRequest<GetActualTeachersQueryResponse>;
