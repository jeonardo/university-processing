using MediatR;

namespace UniversityProcessing.DomainServices.Features.Identity.Refresh.Contracts;

public sealed record RefreshCommandRequest(string RefreshToken) : IRequest<RefreshCommandResponse>;