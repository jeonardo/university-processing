using UniversityProcessing.Abstractions.Http.Universities;
using UniversityProcessing.Abstractions.Http.Universities.University;

namespace UniversityProcessing.DomainServices.Features.UniversityPositions.Get.Contracts;

public sealed record UniversityPositionGetQueryResponse(UniversityPositionDto UniversityPosition);