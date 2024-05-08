using MediatR;

namespace UniversityProcessing.DomainServices.Features.Universities.Create.Contracts;

public sealed record UniversityCreateCommandRequest(string Name, string ShortName) : IRequest<UniversityCreateCommandResponse>;