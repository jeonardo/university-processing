using UniversityProcessing.Abstractions.Http.Universities;
using UniversityProcessing.Abstractions.Http.Universities.Diploma;

namespace UniversityProcessing.DomainServices.Features.DiplomaPeriods.Get.Contracts;

public sealed record DiplomaPeriodGetQueryResponse(DiplomaPeriodDto DiplomaPeriod);