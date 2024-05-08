using MediatR;

namespace UniversityProcessing.DomainServices.Features.Groups.Get.Contracts;

public sealed record GroupGetQueryRequest(Guid Id) : IRequest<GroupGetQueryResponse>;