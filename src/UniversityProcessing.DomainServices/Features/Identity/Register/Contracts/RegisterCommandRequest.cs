using MediatR;

namespace UniversityProcessing.DomainServices.Features.Identity.Register.Contracts;

public sealed record RegisterCommandRequest(string UserName, string Password) : IRequest;