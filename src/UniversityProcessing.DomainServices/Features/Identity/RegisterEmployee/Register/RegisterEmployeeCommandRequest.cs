using MediatR;

namespace UniversityProcessing.DomainServices.Features.Identity.RegisterEmployee.Register;

public sealed record RegisterEmployeeCommandRequest(
    string UserName,
    string Password,
    string FirstName,
    string LastName,
    string? MiddleName = null,
    string? Email = null,
    DateOnly? Birthday = null,
    Guid? UniversityId = null,
    Guid? UniversityPositionId = null) : IRequest;
