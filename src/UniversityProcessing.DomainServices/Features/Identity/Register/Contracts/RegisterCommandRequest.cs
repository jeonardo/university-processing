using MediatR;
using UniversityProcessing.Domain.Identity.Enums;

namespace UniversityProcessing.DomainServices.Features.Identity.Register.Contracts;

public sealed record RegisterCommandRequest(
    UserRoleId UserRoleId,
    string UserName,
    string Password,
    string FirstName,
    string? LastName = null,
    string? MiddleName = null,
    string? Email = null,
    DateOnly? Birthday = null,
    Guid? UniversityId = null,
    Guid? UniversityPositionId = null,
    Guid? GroupId = null) : IRequest;