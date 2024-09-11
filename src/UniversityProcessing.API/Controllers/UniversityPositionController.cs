using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Abstractions.Http.Universities.University;
using UniversityProcessing.DomainServices.Features.UniversityPositions.Get.Contracts;
using UniversityProcessing.DomainServices.Features.UniversityPositions.List.Contracts;
using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class UniversityPositionController(ISender mediator) : ControllerBase
{
    [HttpGet]
    [ValidateModel]
    public async Task<UniversityPositionGetResponseDto> Get([FromQuery] UniversityPositionGetRequestDto request, CancellationToken cancellationToken)
    {
        var query = new UniversityPositionGetQueryRequest(request.Id);
        var response = await mediator.Send(query, cancellationToken);
        return new UniversityPositionGetResponseDto(response.UniversityPosition);
    }

    [HttpGet]
    public async Task<UniversityPositionListResponseDto> GetList([FromQuery] UniversityPositionListRequestDto request, CancellationToken cancellationToken)
    {
        var query = new UniversityPositionListQueryRequest(request.PageNumber, request.PageSize, request.OrderBy, request.Desc);
        var response = await mediator.Send(query, cancellationToken);
        return new UniversityPositionListResponseDto(response.List);
    }
}
