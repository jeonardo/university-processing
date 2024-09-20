using MediatR;

namespace UniversityProcessing.DomainServices.Features.Identity.RegisterStudent;

public sealed record RegisterStudentCommandRequest(
    string UserName,
    string Password,
    string FirstName,
    string LastName,
    string? MiddleName = null,
    string? Email = null,
    DateOnly? Birthday = null,
    string? GroupNumber = null) : IRequest;
