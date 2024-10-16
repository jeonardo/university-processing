using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Abstractions.Http.Universities.User;
using UniversityProcessing.API.Converters;
using UniversityProcessing.DomainServices.Features.Identity.Delete;
using UniversityProcessing.DomainServices.Features.Users.Get;
using UniversityProcessing.DomainServices.Features.Users.GetList;
using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class UserController() : ControllerBase
{
    // [HttpGet] ISender mediator
    // [Authorize]
    // [ValidateModel]
    // public async Task<GetUserResponseDto> GetS([FromQuery] GetUserRequestDto request, CancellationToken cancellationToken)
    // {
    //     var query = new GetUserQueryRequest(request.Id);
    //     var response = await mediator.Send(query, cancellationToken);
    //     return new GetUserResponseDto(UserConverter.ToDto(response.User));
    // }
    //
    // [HttpGet]
    // [Authorize]
    // public async Task<GetUsersResponseDto> GetList([FromQuery] GetUsersRequestDto request, CancellationToken cancellationToken)
    // {
    //     var query = new GetUsersQueryRequest(request.PageNumber, request.PageSize, request.OrderBy, request.Desc);
    //     var response = await mediator.Send(query, cancellationToken);
    //     return new GetUsersResponseDto(UserConverter.ToDto(response.List));
    // }
    //
    // [HttpDelete]
    // [Authorize]
    // [ValidateModel]
    // public Task Delete([FromBody] DeleteUserRequestDto request, CancellationToken cancellationToken)
    // {
    //     var command = new DeleteUserCommandRequest(request.Id);
    //     return mediator.Send(command, cancellationToken);
    // }
}
