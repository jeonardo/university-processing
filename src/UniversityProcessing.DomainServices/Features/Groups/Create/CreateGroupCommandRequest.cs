using MediatR;

namespace UniversityProcessing.DomainServices.Features.Groups.Create;

public sealed record CreateGroupCommandRequest(string GroupNumber, DateOnly StartDate, DateOnly EndDate, Guid? SpecialtyId = null)
    : IRequest<CreateGroupCommandResponse>;
