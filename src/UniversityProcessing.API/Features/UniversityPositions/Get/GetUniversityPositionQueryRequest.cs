using MediatR;

namespace UniversityProcessing.API.Features.UniversityPositions.Get;

public sealed record GetUniversityPositionQueryRequest(Guid Id) : IRequest<GetUniversityPositionQueryResponse>;
