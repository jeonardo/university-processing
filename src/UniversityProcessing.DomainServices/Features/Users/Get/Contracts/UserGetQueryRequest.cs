using MediatR;

namespace UniversityProcessing.DomainServices.Features.Users.Get.Contracts;

public sealed record UserGetQueryRequest(Guid Id) : IRequest<UserGetQueryResponse>;
