using MediatR;

namespace UniversityProcessing.DomainServices.Features.Universities.Get;

public sealed record GetUniversityQueryRequest(Guid Id) : IRequest<GetUniversityQueryResponse>;
