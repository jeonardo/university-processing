using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Abstractions.Http.Universities.DiplomaPeriods;
using UniversityProcessing.API.Converters;
using UniversityProcessing.DomainServices.Features.DiplomaPeriods.Get;
using UniversityProcessing.DomainServices.Features.DiplomaPeriods.GetActuals;
using UniversityProcessing.DomainServices.Features.DiplomaPeriods.GetActualTeachers;

namespace UniversityProcessing.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class DiplomaPeriodController(ISender mediator) : ControllerBase
{
    [HttpGet]
    public async Task<GetDiplomaPeriodResponseDto> Get([FromQuery] GetDiplomaPeriodRequestDto request, CancellationToken cancellationToken)
    {
        var query = new GetDiplomaPeriodQueryRequest(request.Id);
        var response = await mediator.Send(query, cancellationToken);
        return new GetDiplomaPeriodResponseDto(DiplomaPeriodConverter.ToDto(response.DiplomaPeriod));
    }

    [HttpGet]
    public async Task<GetActualDiplomaPeriodsResponseDto> GetActualList([FromQuery] GetActualDiplomaPeriodsRequestDto request, CancellationToken cancellationToken)
    {
        var query = new GetActualDiplomaPeriodsQueryRequest(request.PageNumber, request.PageSize, request.OrderBy, request.Desc);
        var response = await mediator.Send(query, cancellationToken);
        return new GetActualDiplomaPeriodsResponseDto(response.List);
    }

    [HttpPost]
    public async Task<GetActualTeachersResponseDto> GetActualTeachers([FromQuery] GetActualTeachersRequestDto request, CancellationToken cancellationToken)
    {
        var query = new GetActualTeachersQueryRequest(request.PageNumber, request.PageSize, request.OrderBy, request.Desc);
        var response = await mediator.Send(query, cancellationToken);
        return new GetActualTeachersResponseDto(response.List);
    }
}
