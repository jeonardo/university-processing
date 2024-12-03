using MediatR;

namespace UniversityProcessing.API.Features.DiplomaPeriods.Get;

public sealed record GetDiplomaPeriodQueryRequest(Guid Id) : IRequest<GetDiplomaPeriodQueryResponse>;
