using UniversityProcessing.Domain.Identity;

namespace UniversityProcessing.DomainServices.Features.Identity.Refresh.Contracts;

public sealed record RefreshCommandResponse(Token AccessToken, Token RefreshToken);