using MediatR;

namespace UniversityProcessing.DomainServices.Features.Identity.Approve;

public sealed record ApproveUserCommandRequest(Guid UserId) : IRequest;
