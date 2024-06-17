using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Abstractions.Http.Converters;
using UniversityProcessing.Abstractions.Http.Identity;
using UniversityProcessing.Abstractions.Http.Universities.User;
using UniversityProcessing.DomainServices.Core;
using UniversityProcessing.DomainServices.Features.Identity.RegisterAdmin;
using UniversityProcessing.DomainServices.Features.Identity.RegisterEmployee;
using UniversityProcessing.DomainServices.Features.Identity.RegisterStudent;
using UniversityProcessing.DomainServices.Features.Users.Delete.Contracts;
using UniversityProcessing.DomainServices.Features.Users.Get.Contracts;
using UniversityProcessing.DomainServices.Features.Users.List.Contracts;
using UniversityProcessing.GenericSubdomain.Attributes;
using UniversityProcessing.GenericSubdomain.Http;

namespace UniversityProcessing.API.Controllers.Identity;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class IdentityController(IMediator mediator, ITokenService tokenService) : ControllerBase
{
    [HttpGet("{Id}")]
    [ProducesResponseType(typeof(UserGetResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FailResponseDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<UserGetResponseDto> Get([FromRoute] UserGetRequestDto request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new UserGetQueryRequest(request.Id), cancellationToken);
        return new UserGetResponseDto(response.User);
    }

    [HttpGet]
    [ProducesResponseType(typeof(UserListResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FailResponseDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<UserListResponseDto> List([FromQuery] UserListRequestDto request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(
            new UserListQueryRequest(request.PageNumber, request.PageSize, request.OrderBy, request.Desc),
            cancellationToken);
        return new UserListResponseDto(response.List);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FailResponseDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ValidateModel]
    public Task Delete([FromBody] UserDeleteRequestDto request, CancellationToken cancellationToken)
    {
        return mediator.Send(new UserDeleteCommandRequest(request.Id), cancellationToken);
    }

    [HttpPost]
    [ProducesResponseType(typeof(LoginResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FailResponseDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ValidateModel]
    public async Task<LoginResponseDto> Login(
        [FromBody] LoginRequestDto request,
        CancellationToken cancellationToken)
    {
        var response = await mediator.Send(LoginRequestConverter.ToInternal(request), cancellationToken);
        return LoginResponseConverter.ToDto(response);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FailResponseDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FailResponseDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FailResponseDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
    [ProducesResponseType(typeof(LoginResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FailResponseDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [Authorize]
    public async Task<RefreshResponseDto> Refresh(CancellationToken cancellationToken)
    {
        var response = await mediator.Send(RefreshRequestConverter.ToInternal(HttpContext), cancellationToken);
        return RefreshResponseConverter.ToDto(response);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FailResponseDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [Authorize]
    public Task Logout(CancellationToken cancellationToken)
    {
        return mediator.Send(LogoutRequestConverter.ToInternal(), cancellationToken);
    }

    [HttpGet]
    [ProducesResponseType(typeof(InfoResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FailResponseDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [Authorize]
    public InfoResponseDto Info()
    {
        var claims = tokenService.GetAuthorizationTokenClaims(User);
        return new InfoResponseDto(claims.UserId, claims.RoleId.ToDto(), claims.Approved);
    }
}
