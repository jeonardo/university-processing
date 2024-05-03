using MediatR;

namespace UniversityProcessing.DomainServices.Features.Universities.Add.Contracts;

public sealed record UniversityAddCommandRequest(string Name, string ShortName) : IRequest<UniversityAddCommandResponse>;