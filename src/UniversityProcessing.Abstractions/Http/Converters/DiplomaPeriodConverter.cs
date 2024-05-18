using UniversityProcessing.Abstractions.Http.Universities.Diploma;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.Abstractions.Http.Converters;

public static class DiplomaPeriodConverter
{
    public static PagedList<DiplomaPeriodDto> ToPagedDto(IEnumerable<DiplomaPeriod> input, int totalCount, int pageNumber, int pageSize)
    {
        return new PagedList<DiplomaPeriodDto>(ToDto(input), totalCount, pageNumber, pageSize);
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