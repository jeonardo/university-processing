using MediatR;

namespace UniversityProcessing.DomainServices.Features.DiplomaPeriods.Enroll;

public record EnrollDiplomaPeriodCommandRequest(Guid DiplomaPeriodId, Guid UserId) : IRequest;
