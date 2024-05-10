using UniversityProcessing.Abstractions.Http.Universities;
using UniversityProcessing.Abstractions.Http.Universities.Group;

namespace UniversityProcessing.DomainServices.Features.Groups.Get.Contracts;

public sealed record GroupGetQueryResponse(GroupDto Group);