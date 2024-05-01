using UniversityProcessing.Domain;

namespace UniversityProcessing.DomainServices.Features.Identity.Refresh.Contracts;

public sealed record RefreshCommandResponse(Token AccessToken, Token RefreshToken);