using UniversityProcessing.Abstractions.Http.Universities.Specialty;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.API.Converters;

public static class SpecialtyConverter
{
    public static PagedList<SpecialtyDto> ToDto(PagedList<Specialty> input)
    {
        return new PagedList<SpecialtyDto>(ToDto(input.Items), input.TotalCount, input.CurrentPage, input.PageSize);
    }

    public static IEnumerable<SpecialtyDto> ToDto(IEnumerable<Specialty> input)
    {
        return input.Select(ToDto);
    }

    public static SpecialtyDto ToDto(Specialty input)
    {
        return new SpecialtyDto(input.Id, input.Name, input.ShortName, input.Code);
    }
}
