using UniversityProcessing.Domain;
using UniversityProcessing.Domain.Identity;

namespace UniversityProcessing.DomainServices.Features.Identity.Login.Contracts;

public sealed record LoginCommandResponse(Token AccessToken, Token RefreshToken);