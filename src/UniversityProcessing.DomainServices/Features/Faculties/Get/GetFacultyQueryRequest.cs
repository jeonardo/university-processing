using MediatR;

namespace UniversityProcessing.DomainServices.Features.Faculties.Get;

public sealed record GetFacultyQueryRequest(Guid Id) : IRequest<GetFacultyQueryResponse>;
