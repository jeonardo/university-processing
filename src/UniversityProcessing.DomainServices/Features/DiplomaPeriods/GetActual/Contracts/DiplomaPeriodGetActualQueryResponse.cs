using UniversityProcessing.Abstractions.Http.Universities.Diploma;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.DomainServices.Features.DiplomaPeriods.GetActual.Contracts;

public sealed record DiplomaPeriodGetActualQueryResponse(PagedList<DiplomaPeriodDto> List);
