using MediatR;

namespace UniversityProcessing.DomainServices.Features.Identity.Refresh;

public sealed record RefreshCommandRequest(string RefreshToken) : IRequest<RefreshCommandResponse>;
