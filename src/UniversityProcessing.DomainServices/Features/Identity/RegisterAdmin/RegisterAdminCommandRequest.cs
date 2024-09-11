using MediatR;

namespace UniversityProcessing.DomainServices.Features.Identity.RegisterAdmin;

public sealed record RegisterAdminCommandRequest(
    string UserName,
    string Password,
    string FirstName,
    string LastName,
    string? MiddleName = null,
    string? Email = null,
    DateOnly? Birthday = null) : IRequest;
