using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Abstractions.Http.Identity;
using UniversityProcessing.API.Converters;
using UniversityProcessing.DomainServices.Core;
using UniversityProcessing.DomainServices.Features.Identity.Login;
using UniversityProcessing.DomainServices.Features.Identity.Logout;
using UniversityProcessing.DomainServices.Features.Identity.Refresh;
using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.API.Controllers.Identity;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class IdentityController(ISender mediator, ITokenService tokenService) : ControllerBase
{
    [HttpPost]
    [ValidateModel]
    public async Task<LoginResponseDto> Login([FromBody] LoginRequestDto request, CancellationToken cancellationToken)
    {
        var command = new LoginCommandRequest(request.UserName, request.Password);
        var response = await mediator.Send(command, cancellationToken);
        return new LoginResponseDto(TokenConverter.ToDto(response.AccessToken), TokenConverter.ToDto(response.RefreshToken));
    }

    [HttpGet]
    [Authorize]
    public async Task<RefreshResponseDto> Refresh(CancellationToken cancellationToken)
    {
        var refreshToken = HttpContext.Request.Headers.Authorization.ToString();
        var command = new RefreshCommandRequest(refreshToken);
        var response = await mediator.Send(command, cancellationToken);
        return new RefreshResponseDto(TokenConverter.ToDto(response.AccessToken), TokenConverter.ToDto(response.RefreshToken));
    }

    [HttpGet]
    [Authorize]
    public Task Logout(CancellationToken cancellationToken)
    {
        var command = new LogoutCommandRequest();
        return mediator.Send(command, cancellationToken);
    }

    [HttpGet]
    [Authorize]
    public Task<InfoResponseDto> Info(CancellationToken _)
    {
        var claims = tokenService.GetAuthorizationTokenClaims(User);
        return Task.FromResult(new InfoResponseDto(claims.UserId, claims.Roles.ToDto(), claims.Approved));
    }
}
