using UniversityProcessing.Abstractions.Http.Universities.Diploma;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.DomainServices.Features.DiplomaPeriods.GetActuals;

public sealed record GetActualDiplomaPeriodsQueryResponse(PagedList<DiplomaPeriodDto> List);
