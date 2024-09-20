using MediatR;

namespace UniversityProcessing.DomainServices.Features.Groups.Get;

public sealed record GetGroupQueryRequest(Guid Id) : IRequest<GetGroupQueryResponse>;
