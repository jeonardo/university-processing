using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Abstractions.Http.Identity;
using UniversityProcessing.Abstractions.Http.Universities.User;
using UniversityProcessing.API.Converters;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.DomainServices.Core;
using UniversityProcessing.DomainServices.Features.Identity.Approve;
using UniversityProcessing.DomainServices.Features.Identity.Delete;
using UniversityProcessing.DomainServices.Features.Identity.Login;
using UniversityProcessing.DomainServices.Features.Identity.Logout;
using UniversityProcessing.DomainServices.Features.Identity.Refresh;
using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.API.Controllers.Identity;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class IdentityController(ISender mediator, ITokenService tokenService) : ControllerBase
{
    [HttpDelete]
    [ValidateModel]
    public Task Delete([FromBody] DeleteUserRequestDto request, CancellationToken cancellationToken)
    {
        var command = new DeleteUserCommandRequest(request.Id);
        return mediator.Send(command, cancellationToken);
    }

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
    public Task<InfoResponseDto> Info()
    {
        var claims = tokenService.GetAuthorizationTokenClaims(User);
        return Task.FromResult(new InfoResponseDto(claims.UserId, claims.Roles.ToDto(), claims.Approved));
    }

    [HttpPost]
    [Authorize(Roles = nameof(UserRoles.ApplicationAdmin))]
    [ValidateModel]
    public Task Approve([FromBody] ApproveUserRequestDto request, CancellationToken cancellationToken)
    {
        var command = new ApproveUserCommandRequest(request.UserId);
        return mediator.Send(command, cancellationToken);
    }
}
