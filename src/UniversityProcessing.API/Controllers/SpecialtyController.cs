using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Abstractions.Http.Universities.Specialty;
using UniversityProcessing.DomainServices.Features.Specialties.Create.Contracts;
using UniversityProcessing.DomainServices.Features.Specialties.Delete.Contracts;
using UniversityProcessing.DomainServices.Features.Specialties.Get.Contracts;
using UniversityProcessing.DomainServices.Features.Specialties.List.Contracts;
using UniversityProcessing.GenericSubdomain.Attributes;
using UniversityProcessing.GenericSubdomain.Http;

namespace UniversityProcessing.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class SpecialtyController(IMediator mediator) : ControllerBase
{
    [HttpGet("{Id}")]
    [ProducesResponseType(typeof(SpecialtyGetResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FailResponseDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<SpecialtyGetResponseDto> Get([FromRoute] SpecialtyGetRequestDto request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new SpecialtyGetQueryRequest(request.Id), cancellationToken);
        return new SpecialtyGetResponseDto(response.Specialty);
    }

    [HttpGet]
    [ProducesResponseType(typeof(SpecialtyListResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FailResponseDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<SpecialtyListResponseDto> List([FromQuery] SpecialtyListRequestDto request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(
            new SpecialtyListQueryRequest(request.PageNumber, request.PageSize, request.OrderBy, request.Desc),
            cancellationToken);
        return new SpecialtyListResponseDto(response.List);
    }

    [HttpPost]
    [ProducesResponseType(typeof(SpecialtyCreateResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FailResponseDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ValidateModel]
    public async Task<SpecialtyCreateResponseDto> Create([FromQuery] SpecialtyCreateRequestDto request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(
            new SpecialtyCreateCommandRequest(request.Name, request.ShortName, request.Code, request.FacultyId),
            cancellationToken);
        return new SpecialtyCreateResponseDto(response.Id);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FailResponseDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ValidateModel]
    public Task Delete([FromBody] SpecialtyDeleteRequestDto request, CancellationToken cancellationToken)
    {
        return mediator.Send(new SpecialtyDeleteCommandRequest(request.Id), cancellationToken);
    }
}