using MediatR;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;

namespace UniversityProcessing.API.TODO.Endpoints.Employee.Teacher.DepartmentLeader.DiplomaProcesses.Get;

internal sealed class GetDiplomaPeriodQueryHandler(IEfReadRepository<DiplomaProcess> repository)
    : IRequestHandler<GetDiplomaPeriodQueryRequest, GetDiplomaPeriodQueryResponse>
{
    public async Task<GetDiplomaPeriodQueryResponse> Handle(GetDiplomaPeriodQueryRequest request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdRequiredAsync(request.Id, cancellationToken);
        return new GetDiplomaPeriodQueryResponse(entity);
    }
}
