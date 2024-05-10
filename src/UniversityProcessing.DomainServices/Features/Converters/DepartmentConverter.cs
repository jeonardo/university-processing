using UniversityProcessing.Abstractions.Http.Universities.Department;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.DomainServices.Features.Converters;

public static class DepartmentConverter
{
    public static PagedList<DepartmentDto> ToPagedDto(IEnumerable<Department> input, int totalCount, int pageNumber, int pageSize)
    {
        return new PagedList<DepartmentDto>(ToDto(input), totalCount, pageNumber, pageSize);
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