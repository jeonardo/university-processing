using UniversityProcessing.Abstractions.Http.Universities;

namespace UniversityProcessing.DomainServices.Features.Groups.Get.Contracts;

public sealed record GroupGetQueryResponse(GroupDto Group);