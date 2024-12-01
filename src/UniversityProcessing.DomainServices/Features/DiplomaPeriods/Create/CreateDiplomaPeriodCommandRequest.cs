using MediatR;

namespace UniversityProcessing.DomainServices.Features.DiplomaPeriods.Create;

public sealed record CreateDiplomaPeriodCommandRequest(DateTime StartDate, DateTime EndDate, Guid? FacultyId = null) : IRequest<CreateDiplomaPeriodCommandResponse>;
