using UniversityProcessing.Domain;

namespace UniversityProcessing.DomainServices.Features.Identity.Login;

public sealed record LoginCommandResponse(Token AccessToken, Token RefreshToken);
