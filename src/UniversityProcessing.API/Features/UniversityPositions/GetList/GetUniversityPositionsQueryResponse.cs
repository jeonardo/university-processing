using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.API.Features.UniversityPositions.GetList;

public sealed record GetUniversityPositionsQueryResponse(PagedList<UniversityPosition> List);
