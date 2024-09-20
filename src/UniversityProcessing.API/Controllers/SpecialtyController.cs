using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Abstractions.Http.Universities.Specialty;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.DomainServices.Features.Specialties.Create;
using UniversityProcessing.DomainServices.Features.Specialties.Delete;
using UniversityProcessing.DomainServices.Features.Specialties.Get;
using UniversityProcessing.DomainServices.Features.Specialties.GetList;
using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class SpecialtyController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ValidateModel]
    public async Task<GetSpecialtyResponseDto> Get([FromQuery] GetSpecialtyRequestDto request, CancellationToken cancellationToken)
    {
        var query = new GetSpecialtyQueryRequest(request.Id);
        var response = await mediator.Send(query, cancellationToken);
        return new GetSpecialtyResponseDto(response.Specialty);
    }

    [HttpGet]
    public async Task<GetSpecialtiesResponseDto> GetList([FromQuery] GetSpecialtiesRequestDto request, CancellationToken cancellationToken)
    {
        var query = new GetSpecialtiesQueryRequest(request.PageNumber, request.PageSize, request.OrderBy, request.Desc);
        var response = await mediator.Send(query, cancellationToken);
        return new GetSpecialtiesResponseDto(response.List);
    }

    [HttpPost]
    [Authorize(Roles = nameof(UserRoles.ApplicationAdmin))]
    [ValidateModel]
    public async Task<CreateSpecialtyResponseDto> Create([FromBody] CreateSpecialtyRequestDto request, CancellationToken cancellationToken)
    {
        var command = new CreateSpecialtyCommandRequest(request.Name, request.ShortName, request.Code, request.FacultyId);
        var response = await mediator.Send(command, cancellationToken);
        return new CreateSpecialtyResponseDto(response.Id);
    }

    [HttpDelete]
    [Authorize(Roles = nameof(UserRoles.ApplicationAdmin))]
    [ValidateModel]
    public Task Delete([FromBody] DeleteSpecialtyRequestDto request, CancellationToken cancellationToken)
    {
        return mediator.Send(new DeleteSpecialtyCommandRequest(request.Id), cancellationToken);
    }
}
