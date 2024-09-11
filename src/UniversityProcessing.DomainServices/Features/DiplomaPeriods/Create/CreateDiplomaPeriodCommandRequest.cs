using MediatR;

namespace UniversityProcessing.DomainServices.Features.DiplomaPeriods.Create;

public sealed record CreateDiplomaPeriodCommandRequest(DateOnly StartDate, DateOnly EndDate, Guid? FacultyId = null) : IRequest<CreateDiplomaPeriodCommandResponse>;
