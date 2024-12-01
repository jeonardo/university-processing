using MediatR;

namespace UniversityProcessing.DomainServices.Features.Groups.Create;

public sealed record CreateGroupCommandRequest(string GroupNumber, DateTime StartDate, DateTime EndDate, Guid? SpecialtyId = null)
    : IRequest<CreateGroupCommandResponse>;
