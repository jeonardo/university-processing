using MediatR;

namespace UniversityProcessing.DomainServices.Features.DiplomaPeriods.Delete;

public sealed record DeleteDiplomaPeriodCommandRequest(Guid Id) : IRequest;
