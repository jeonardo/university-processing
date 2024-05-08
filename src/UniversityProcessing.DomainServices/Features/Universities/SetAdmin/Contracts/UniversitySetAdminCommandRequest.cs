using MediatR;

namespace UniversityProcessing.DomainServices.Features.Universities.SetAdmin.Contracts;

public sealed record UniversitySetAdminCommandRequest(Guid UniversityId, Guid UserId) : IRequest
{
}