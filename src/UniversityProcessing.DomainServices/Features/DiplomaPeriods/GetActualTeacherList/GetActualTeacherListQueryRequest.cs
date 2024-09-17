using MediatR;

namespace UniversityProcessing.DomainServices.Features.DiplomaPeriods.GetActualTeacherList;

public sealed record GetActualTeacherListQueryRequest : IRequest<GetActualTeacherListQueryResponse>
{
}
