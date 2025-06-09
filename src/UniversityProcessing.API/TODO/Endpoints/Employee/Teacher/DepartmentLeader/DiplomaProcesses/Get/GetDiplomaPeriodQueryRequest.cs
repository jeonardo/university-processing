using MediatR;

namespace UniversityProcessing.API.TODO.Endpoints.Employee.Teacher.DepartmentLeader.DiplomaProcesses.Get;

public sealed class GetDiplomaPeriodQueryRequest(Guid id) : IRequest<GetDiplomaPeriodQueryResponse>
{
    public Guid Id { get; set; } = id;
}
