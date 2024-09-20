using MediatR;

namespace UniversityProcessing.DomainServices.Features.UniversityPositions.Get;

public sealed record GetUniversityPositionQueryRequest(Guid Id) : IRequest<GetUniversityPositionQueryResponse>;
