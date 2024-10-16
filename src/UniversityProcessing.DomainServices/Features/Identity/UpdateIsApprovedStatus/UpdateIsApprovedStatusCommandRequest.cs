using MediatR;

namespace UniversityProcessing.DomainServices.Features.Identity.UpdateIsApprovedStatus;

public sealed record UpdateIsApprovedStatusCommandRequest(Guid UserId, bool IsApproved) : IRequest;
