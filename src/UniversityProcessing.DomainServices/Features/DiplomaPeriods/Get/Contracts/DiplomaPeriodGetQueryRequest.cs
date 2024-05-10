using MediatR;

namespace UniversityProcessing.DomainServices.Features.DiplomaPeriods.Get.Contracts;

public sealed record DiplomaPeriodGetQueryRequest(Guid Id) : IRequest<DiplomaPeriodGetQueryResponse>;