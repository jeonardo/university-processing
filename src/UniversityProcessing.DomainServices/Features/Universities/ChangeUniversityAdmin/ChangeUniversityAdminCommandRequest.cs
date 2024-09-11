using MediatR;

namespace UniversityProcessing.DomainServices.Features.Universities.ChangeUniversityAdmin;

public sealed record ChangeUniversityAdminCommandRequest(Guid UniversityId, Guid UserId) : IRequest;
