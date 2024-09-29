using UniversityProcessing.Abstractions.Http.Universities.Department;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.API.Converters;

public static class DepartmentConverter
{
    public static PagedList<DepartmentDto> ToDto(PagedList<Department> input)
    {
        return new PagedList<DepartmentDto>(ToDto(input.Items), input.TotalCount, input.CurrentPage, input.PageSize);
    }

    public static IEnumerable<DepartmentDto> ToDto(IEnumerable<Department> input)
    {
        return input.Select(ToDto);
    }

    public static DepartmentDto ToDto(Department input)
    {
        return new DepartmentDto(input.Id, input.Name, input.ShortName);
    }
}
