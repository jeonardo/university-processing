using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Abstractions.Http.Identity;
using UniversityProcessing.API.Converters;
using UniversityProcessing.GenericSubdomain.Attributes;
using UniversityProcessing.GenericSubdomain.Http;

namespace UniversityProcessing.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class IdentityController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(LoginResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FailResponse), StatusCodes.Status400BadRequest)]
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
    [ProducesResponseType(typeof(FailResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ValidateModel]
    public Task Register([FromBody] RegisterRequestDto request, CancellationToken cancellationToken)
    {
        return mediator.Send(RegisterRequestConverter.ToInternal(request), cancellationToken);
    }

    [HttpGet]
    [ProducesResponseType(typeof(LoginResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FailResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [Authorize]
    public async Task<RefreshResponseDto> Refresh(CancellationToken cancellationToken)
    {
        var token = HttpContext.Request.Headers.Authorization;
        var response = await mediator.Send(RefreshRequestConverter.ToInternal(token), cancellationToken);
        return RefreshResponseConverter.ToDto(response);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FailResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [Authorize]
    public Task Logout(CancellationToken cancellationToken)
    {
        return mediator.Send(LogoutRequestConverter.ToInternal(), cancellationToken);
    }
}