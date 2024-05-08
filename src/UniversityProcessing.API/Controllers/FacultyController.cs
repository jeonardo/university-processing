using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Abstractions.Http.Universities;
using UniversityProcessing.DomainServices.Features.Faculties.Create.Contracts;
using UniversityProcessing.DomainServices.Features.Faculties.Delete.Contracts;
using UniversityProcessing.DomainServices.Features.Faculties.Get.Contracts;
using UniversityProcessing.DomainServices.Features.Faculties.List.Contracts;
using UniversityProcessing.GenericSubdomain.Attributes;
using UniversityProcessing.GenericSubdomain.Http;

namespace UniversityProcessing.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class FacultyController(IMediator mediator) : ControllerBase
{
    [HttpGet("{Id}")]
    [ProducesResponseType(typeof(FacultyGetResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FailResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<FacultyGetResponseDto> Get([FromRoute] FacultyGetRequestDto request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new FacultyGetQueryRequest(request.Id), cancellationToken);
        return new FacultyGetResponseDto(response.Faculty);
    }

    [HttpGet]
    [ProducesResponseType(typeof(FacultyListResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FailResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<FacultyListResponseDto> List([FromQuery] FacultyListRequestDto request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(
            new FacultyListQueryRequest(request.PageNumber, request.PageSize, request.OrderBy, request.Desc),
            cancellationToken);
        return new FacultyListResponseDto(response.List);
    }

    [HttpPost]
    [ProducesResponseType(typeof(FacultyCreateResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FailResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ValidateModel]
    public async Task<FacultyCreateResponseDto> Create([FromQuery] FacultyCreateRequestDto request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new FacultyCreateCommandRequest(request.Name, request.ShortName, request.UniversityId), cancellationToken);
        return new FacultyCreateResponseDto(response.Id);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FailResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ValidateModel]
    public Task Delete([FromBody] FacultyDeleteRequestDto request, CancellationToken cancellationToken)
    {
        return mediator.Send(new FacultyDeleteCommandRequest(request.Id), cancellationToken);
    }
}