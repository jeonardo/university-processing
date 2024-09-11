using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Abstractions.Http.Converters;
using UniversityProcessing.Abstractions.Http.Identity;
using UniversityProcessing.Abstractions.Http.Universities.User;
using UniversityProcessing.API.Converters;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.DomainServices.Core;
using UniversityProcessing.DomainServices.Features.Identity.Approve.Contracts;
using UniversityProcessing.DomainServices.Features.Identity.Login.Contracts;
using UniversityProcessing.DomainServices.Features.Identity.Logout.Contracts;
using UniversityProcessing.DomainServices.Features.Identity.Refresh.Contracts;
using UniversityProcessing.DomainServices.Features.Identity.RegisterAdmin;
using UniversityProcessing.DomainServices.Features.Identity.RegisterEmployee;
using UniversityProcessing.DomainServices.Features.Identity.RegisterStudent;
using UniversityProcessing.DomainServices.Features.Users.Delete.Contracts;
using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class IdentityController(ISender mediator, ITokenService tokenService) : ControllerBase
{
    [HttpDelete]
    [ValidateModel]
    public Task Delete([FromBody] UserDeleteRequestDto request, CancellationToken cancellationToken)
    {
        var command = new UserDeleteCommandRequest(request.Id);
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

    [HttpPost]
    [ValidateModel]
    public Task RegisterEmployee([FromBody] RegisterEmployeeRequestDto request, CancellationToken cancellationToken)
    {
        var command = new RegisterEmployeeCommandRequest(
            request.UserName,
            request.Password,
            request.FirstName,
            request.LastName,
            request.MiddleName,
            request.Email,
            request.Birthday,
            request.UniversityId,
            request.UniversityPositionId);
        return mediator.Send(command, cancellationToken);
    }

    [HttpPost]
    [ValidateModel]
    public Task RegisterAdmin([FromBody] RegisterAdminRequestDto request, CancellationToken cancellationToken)
    {
        var command = new RegisterAdminCommandRequest(
            request.UserName,
            request.Password,
            request.FirstName,
            request.LastName,
            request.MiddleName,
            request.Email,
            request.Birthday);
        return mediator.Send(command, cancellationToken);
    }

    [HttpPost]
    [ValidateModel]
    public Task RegisterStudent([FromBody] RegisterStudentRequestDto request, CancellationToken cancellationToken)
    {
        var command = new RegisterStudentCommandRequest(
            request.UserName,
            request.Password,
            request.FirstName,
            request.LastName,
            request.MiddleName,
            request.Email,
            request.Birthday,
            request.GroupId);
        return mediator.Send(command, cancellationToken);
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
    public InfoResponseDto Info()
    {
        var claims = tokenService.GetAuthorizationTokenClaims(User);
        return new InfoResponseDto(claims.UserId, claims.Roles.ToDto(), claims.Approved);
    }

    [HttpPost]
    [Authorize(Roles = nameof(UserRoles.ApplicationAdmin))]
    [ValidateModel]
    public Task Approve([FromBody] ApproveUserRequestDto request, CancellationToken cancellationToken)
    {
        var command = new UserApproveCommandRequest(request.UserId);
        return mediator.Send(command, cancellationToken);
    }
}
