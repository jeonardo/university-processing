using MediatR;

namespace UniversityProcessing.DomainServices.Features.DiplomaPeriods.GetActualTeacherList;

internal sealed class GetActualTeacherListQueryHandler : IRequestHandler<GetActualTeacherListQueryRequest, GetActualTeacherListQueryResponse>
{
    public Task<GetActualTeacherListQueryResponse> Handle(GetActualTeacherListQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
