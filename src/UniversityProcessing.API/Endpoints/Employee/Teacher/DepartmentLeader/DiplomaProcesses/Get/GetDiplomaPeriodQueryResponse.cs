using UniversityProcessing.Domain;

namespace UniversityProcessing.API.Endpoints.Employee.Teacher.DepartmentLeader.DiplomaProcesses.Get;

public sealed class GetDiplomaPeriodQueryResponse(DiplomaProcess diplomaProcess)
{
    public DiplomaProcess DiplomaProcess { get; set; } = diplomaProcess;
}
