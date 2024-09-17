using UniversityProcessing.Abstractions.Http.Universities.Diploma;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.DomainServices.Features.DiplomaPeriods.GetActualList;

public sealed record GetActualDiplomaPeriodListQueryResponse(PagedList<DiplomaPeriodDto> List);
