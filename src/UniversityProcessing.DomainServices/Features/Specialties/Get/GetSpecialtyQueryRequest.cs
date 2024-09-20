using MediatR;

namespace UniversityProcessing.DomainServices.Features.Specialties.Get;

public sealed record GetSpecialtyQueryRequest(Guid Id) : IRequest<GetSpecialtyQueryResponse>;
