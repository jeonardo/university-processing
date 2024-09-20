using MediatR;

namespace UniversityProcessing.DomainServices.Features.Users.Get;

public sealed record GetUserQueryRequest(Guid Id) : IRequest<GetUserQueryResponse>;
