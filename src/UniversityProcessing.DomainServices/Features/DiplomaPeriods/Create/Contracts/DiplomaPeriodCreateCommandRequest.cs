using MediatR;

namespace UniversityProcessing.DomainServices.Features.DiplomaPeriods.Create.Contracts;

public record DiplomaPeriodCreateCommandRequest(Guid FacultyId, DateOnly StartDate, DateOnly EndDate) : IRequest<DiplomaPeriodCreateCommandResponse>;
