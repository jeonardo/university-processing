using MediatR;

namespace UniversityProcessing.API.Features.DiplomaPeriods.GetActualTeachers;

internal sealed class GetActualTeachersQueryHandler : IRequestHandler<GetActualTeachersQueryRequest, GetActualTeachersQueryResponse>
{
    public Task<GetActualTeachersQueryResponse> Handle(GetActualTeachersQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
