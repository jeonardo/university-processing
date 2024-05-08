using MediatR;

namespace UniversityProcessing.DomainServices.Features.Faculties.Get.Contracts;

public sealed record FacultyGetQueryRequest(Guid Id) : IRequest<FacultyGetQueryResponse>;