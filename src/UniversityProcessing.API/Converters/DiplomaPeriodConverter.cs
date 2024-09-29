using UniversityProcessing.Abstractions.Http.Universities.Diploma;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.API.Converters;

public static class DiplomaPeriodConverter
{
    public static PagedList<DiplomaPeriodDto> ToDto(PagedList<DiplomaPeriod> input)
    {
        return new PagedList<DiplomaPeriodDto>(ToDto(input.Items), input.TotalCount, input.CurrentPage, input.PageSize);
    }

    public static IEnumerable<DiplomaPeriodDto> ToDto(IEnumerable<DiplomaPeriod> input)
    {
        return input.Select(ToDto);
    }

    public static DiplomaPeriodDto ToDto(DiplomaPeriod input)
    {
        return new DiplomaPeriodDto(input.Id, input.StartDate, input.EndDate);
    }
}
