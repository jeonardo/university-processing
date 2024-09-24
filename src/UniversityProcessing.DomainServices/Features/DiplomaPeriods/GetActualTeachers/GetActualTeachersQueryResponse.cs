using UniversityProcessing.Abstractions.Http.Universities.DiplomaPeriods;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.DomainServices.Features.DiplomaPeriods.GetActualTeachers;

public sealed record GetActualTeachersQueryResponse(PagedList<TeacherDto> List);
