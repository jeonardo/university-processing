using MediatR;

namespace UniversityProcessing.DomainServices.Features.DiplomaPeriods.GetActualTeacherList;

internal sealed class GetActualTeachersQueryHandler : IRequestHandler<GetActualTeachersQueryRequest, GetActualTeachersQueryResponse>
{
    public Task<GetActualTeachersQueryResponse> Handle(GetActualTeachersQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
