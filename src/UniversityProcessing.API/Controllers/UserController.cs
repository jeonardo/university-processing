using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Abstractions.Http.Universities.User;
using UniversityProcessing.API.Converters;
using UniversityProcessing.DomainServices.Features.Users.Get;
using UniversityProcessing.DomainServices.Features.Users.GetList;
using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class UserController(ISender mediator) : ControllerBase
{
    [HttpGet]
    [Authorize]
    [ValidateModel]
    public async Task<GetUserResponseDto> Get([FromQuery] GetUserRequestDto request, CancellationToken cancellationToken)
    {
        var query = new GetUserQueryRequest(request.Id);
        var response = await mediator.Send(query, cancellationToken);
        return new GetUserResponseDto(UserConverter.ToDto(response.User));
    }

    [HttpGet]
    [Authorize]
    public async Task<GetUsersResponseDto> GetList([FromQuery] GetUsersRequestDto request, CancellationToken cancellationToken)
    {
        var query = new GetUsersQueryRequest(request.PageNumber, request.PageSize, request.OrderBy, request.Desc);
        var response = await mediator.Send(query, cancellationToken);
        return new GetUsersResponseDto(UserConverter.ToDto(response.List));
    }
}
