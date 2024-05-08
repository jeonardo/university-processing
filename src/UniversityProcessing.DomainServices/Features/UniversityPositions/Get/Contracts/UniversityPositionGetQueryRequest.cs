using MediatR;

namespace UniversityProcessing.DomainServices.Features.UniversityPositions.Get.Contracts;

public sealed record UniversityPositionGetQueryRequest(Guid Id) : IRequest<UniversityPositionGetQueryResponse>;