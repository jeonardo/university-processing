using UniversityProcessing.Abstractions.Http.Universities;
using UniversityProcessing.Abstractions.Http.Universities.Faculty;

namespace UniversityProcessing.DomainServices.Features.Faculties.Get.Contracts;

public sealed record FacultyGetQueryResponse(FacultyDto Faculty);