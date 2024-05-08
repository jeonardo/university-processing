using MediatR;

namespace UniversityProcessing.DomainServices.Features.Specialties.Get.Contracts;

public sealed record SpecialtyGetQueryRequest(Guid Id) : IRequest<SpecialtyGetQueryResponse>;