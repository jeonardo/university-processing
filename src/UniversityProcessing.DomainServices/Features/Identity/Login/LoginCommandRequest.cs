using MediatR;

namespace UniversityProcessing.DomainServices.Features.Identity.Login;

public sealed record LoginCommandRequest(string UserName, string Password) : IRequest<LoginCommandResponse>;
