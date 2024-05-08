using MediatR;

namespace UniversityProcessing.DomainServices.Features.Universities.Get.Contracts;

public sealed record UniversityGetQueryRequest(Guid Id) : IRequest<UniversityGetQueryResponse>;