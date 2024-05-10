using UniversityProcessing.Abstractions.Http.Universities;
using UniversityProcessing.Abstractions.Http.Universities.University;

namespace UniversityProcessing.DomainServices.Features.Universities.Get.Contracts;

public sealed record UniversityGetQueryResponse(UniversityDto University);