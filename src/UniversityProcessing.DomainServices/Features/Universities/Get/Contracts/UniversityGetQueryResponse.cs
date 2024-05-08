using UniversityProcessing.Abstractions.Http.Universities;

namespace UniversityProcessing.DomainServices.Features.Universities.Get.Contracts;

public sealed record UniversityGetQueryResponse(UniversityDto University);