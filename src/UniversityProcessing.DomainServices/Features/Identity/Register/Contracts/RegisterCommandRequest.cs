using MediatR;
using UniversityProcessing.Domain.Identity.Enums;

namespace UniversityProcessing.DomainServices.Features.Identity.Register.Contracts;

public sealed record RegisterCommandRequest(
    UserRoleId UserRoleId,
    string UserName,
    string Password,
    string FirstName,
    string? LastName,
    string? MiddleName,
    string? Email,
    DateOnly? Birthday) : IRequest;