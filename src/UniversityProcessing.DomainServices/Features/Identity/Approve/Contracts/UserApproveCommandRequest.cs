using MediatR;

namespace UniversityProcessing.DomainServices.Features.Identity.Approve.Contracts;

public sealed record UserApproveCommandRequest(Guid UserId) : IRequest;