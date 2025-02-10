using MediatR;

namespace UniversityProcessing.API.Endpoints.Employee.Teacher.DepartmentLeader.DiplomaProcesses.Get;

public sealed record GetDiplomaPeriodQueryRequest(Guid Id) : IRequest<GetDiplomaPeriodQueryResponse>;
