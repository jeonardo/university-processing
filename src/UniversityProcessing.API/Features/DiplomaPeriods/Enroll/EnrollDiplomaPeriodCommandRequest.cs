using MediatR;

namespace UniversityProcessing.API.Features.DiplomaPeriods.Enroll;

public record EnrollDiplomaPeriodCommandRequest(Guid DiplomaPeriodId, Guid UserId) : IRequest;
