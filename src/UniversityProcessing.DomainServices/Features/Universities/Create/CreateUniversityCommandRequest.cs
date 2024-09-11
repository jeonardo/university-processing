using MediatR;

namespace UniversityProcessing.DomainServices.Features.Universities.Create;

public sealed record CreateUniversityCommandRequest(string Name, string ShortName, Guid? AdminId = null) : IRequest<CreateUniversityCommandResponse>;
