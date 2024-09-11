using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Abstractions.Http.Universities.Specialty;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.DomainServices.Features.Specialties.Create;
using UniversityProcessing.DomainServices.Features.Specialties.Delete.Contracts;
using UniversityProcessing.DomainServices.Features.Specialties.Get.Contracts;
using UniversityProcessing.DomainServices.Features.Specialties.List.Contracts;
using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class SpecialtyController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ValidateModel]
    public async Task<SpecialtyGetResponseDto> Get([FromQuery] SpecialtyGetRequestDto request, CancellationToken cancellationToken)
    {
        var query = new SpecialtyGetQueryRequest(request.Id);
        var response = await mediator.Send(query, cancellationToken);
        return new SpecialtyGetResponseDto(response.Specialty);
    }

    [HttpGet]
    public async Task<SpecialtyListResponseDto> GetList([FromQuery] SpecialtyListRequestDto request, CancellationToken cancellationToken)
    {
        var query = new SpecialtyListQueryRequest(request.PageNumber, request.PageSize, request.OrderBy, request.Desc);
        var response = await mediator.Send(query, cancellationToken);
        return new SpecialtyListResponseDto(response.List);
    }

    [HttpPost]
    [Authorize(Roles = nameof(UserRoles.ApplicationAdmin))]
    [ValidateModel]
    public async Task<SpecialtyCreateResponseDto> Create([FromBody] SpecialtyCreateRequestDto request, CancellationToken cancellationToken)
    {
        var command = new CreateSpecialtyCommandRequest(request.Name, request.ShortName, request.Code, request.FacultyId);
        var response = await mediator.Send(command, cancellationToken);
        return new SpecialtyCreateResponseDto(response.Id);
    }

    [HttpDelete]
    [Authorize(Roles = nameof(UserRoles.ApplicationAdmin))]
    [ValidateModel]
    public Task Delete([FromBody] SpecialtyDeleteRequestDto request, CancellationToken cancellationToken)
    {
        return mediator.Send(new SpecialtyDeleteCommandRequest(request.Id), cancellationToken);
    }
}
