using MediatR;

namespace UniversityProcessing.DomainServices.Features.DiplomaPeriods.Get;

public sealed record GetDiplomaPeriodQueryRequest(Guid Id) : IRequest<GetDiplomaPeriodQueryResponse>;
