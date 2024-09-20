using MediatR;

namespace UniversityProcessing.DomainServices.Features.DiplomaPeriods.GetActualTeacherList;

public sealed record GetActualTeachersQueryRequest : IRequest<GetActualTeachersQueryResponse>
{
}
