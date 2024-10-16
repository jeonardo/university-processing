using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Abstractions.Http.Admin;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.DomainServices.Features.Identity.UpdateIsApprovedStatus;
using UniversityProcessing.DomainServices.Features.Users.GetList;
using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.API.Controllers.Admin;

[ApiController]
[Route("api/v1/[controller]/[action]")]
[Authorize(Roles = nameof(UserRoles.ApplicationAdmin))]
public class AdminController(ISender mediator) : ControllerBase
{
    [HttpGet]
    public async Task<AdminGetUsersResponseDto> GetUsers([FromQuery] AdminGetUsersRequestDto request, CancellationToken cancellationToken)
    {
        var query = new GetUsersQueryRequest(request.PageNumber, request.PageSize, request.OrderBy, request.Desc);
        var response = await mediator.Send(query, cancellationToken);
        return response.ToAdminGetUsersResponseDto();
    }

    [HttpPut]
    [ValidateModel]
    public Task UpdateIsApprovedStatus([FromBody] UpdateIsApprovedStatusRequestDto request, CancellationToken cancellationToken)
    {
        var command = new UpdateIsApprovedStatusCommandRequest(request.UserId, request.IsApproved);
        return mediator.Send(command, cancellationToken);
    }
}
