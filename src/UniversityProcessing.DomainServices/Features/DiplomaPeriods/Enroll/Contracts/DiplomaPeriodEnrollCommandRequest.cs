using MediatR;

namespace UniversityProcessing.DomainServices.Features.DiplomaPeriods.Enroll.Contracts;

public record DiplomaPeriodEnrollCommandRequest(Guid DiplomaPeriodId, Guid UserId) : IRequest;
