using MediatR;

namespace UniversityProcessing.DomainServices.Features.Identity.Login.Contracts;

public sealed record LoginCommandRequest(string UserName, string Password) : IRequest<LoginCommandResponse>;