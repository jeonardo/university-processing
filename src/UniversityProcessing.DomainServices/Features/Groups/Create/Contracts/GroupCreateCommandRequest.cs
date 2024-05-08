using MediatR;

namespace UniversityProcessing.DomainServices.Features.Groups.Create.Contracts;

public sealed record GroupCreateCommandRequest(string GroupNumber, DateOnly StartDate, DateOnly EndDate, Guid SpecialtyId)
    : IRequest<GroupCreateCommandResponse>;