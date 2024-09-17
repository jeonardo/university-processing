using MediatR;

namespace UniversityProcessing.DomainServices.Features.Identity.Delete;

public sealed record UserDeleteCommandRequest(Guid Id) : IRequest;
