using MediatR;

namespace UniversityProcessing.DomainServices.Features.Groups.Delete;

public sealed record DeleteGroupCommandRequest(Guid Id) : IRequest;
