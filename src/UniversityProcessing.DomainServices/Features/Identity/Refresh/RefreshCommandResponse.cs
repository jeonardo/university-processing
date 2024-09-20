using UniversityProcessing.Domain;

namespace UniversityProcessing.DomainServices.Features.Identity.Refresh;

public sealed record RefreshCommandResponse(Token AccessToken, Token RefreshToken);
