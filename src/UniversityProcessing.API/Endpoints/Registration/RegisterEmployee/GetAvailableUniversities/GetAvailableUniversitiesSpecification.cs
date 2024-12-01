using Ardalis.Specification;
using UniversityProcessing.Domain.UniversityStructure;

namespace UniversityProcessing.API.Endpoints.Registration.RegisterEmployee.GetAvailableUniversities;

internal sealed class GetAvailableUniversitiesSpecification : Specification<University, UniversityDto>
{
    public GetAvailableUniversitiesSpecification(string name)
    {
        Query
            .Select(x => new UniversityDto(x.Id, x.ShortName))
            .AsNoTracking()
            .Where(x => x.Name.Contains(name) || x.ShortName.Contains(name))
            .Take(10);
    }
}
