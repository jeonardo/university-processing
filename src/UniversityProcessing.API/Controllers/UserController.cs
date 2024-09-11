using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Abstractions.Http.Universities.User;
using UniversityProcessing.DomainServices.Features.Users.Get.Contracts;
using UniversityProcessing.DomainServices.Features.Users.List.Contracts;
using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class UserController(ISender mediator) : ControllerBase
{
    [HttpGet]
    [Authorize]
    [ValidateModel]
    public async Task<UserGetResponseDto> Get([FromQuery] UserGetRequestDto request, CancellationToken cancellationToken)
    {
        var query = new UserGetQueryRequest(request.Id);
        var response = await mediator.Send(query, cancellationToken);
        return new UserGetResponseDto(response.User);
    }

    [HttpGet]
    [Authorize]
    public async Task<UserListResponseDto> GetList([FromQuery] UserListRequestDto request, CancellationToken cancellationToken)
    {
        var query = new UserListQueryRequest(request.PageNumber, request.PageSize, request.OrderBy, request.Desc);
        var response = await mediator.Send(query, cancellationToken);
        return new UserListResponseDto(response.List);
    }
}
