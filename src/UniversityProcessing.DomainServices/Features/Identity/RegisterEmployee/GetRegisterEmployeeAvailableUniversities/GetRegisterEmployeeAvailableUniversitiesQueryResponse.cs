using UniversityProcessing.Abstractions.Http.Identity.RegisterEmployee;

namespace UniversityProcessing.DomainServices.Features.Identity.RegisterEmployee.GetRegisterEmployeeAvailableUniversities;

public sealed record GetRegisterEmployeeAvailableUniversitiesQueryResponse(RegisterEmployeeUniversityDto[] Universities);