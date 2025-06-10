using Ardalis.Specification;
using UniversityProcessing.Domain;

namespace UniversityProcessing.API.Endpoints.Auth.Registration.Employee.GetAvailableUniversityPositions;

internal sealed class GetAvailableUniversityPositionsSpecification : Specification<UniversityPosition, UniversityPositionDto>
{
    public GetAvailableUniversityPositionsSpecification()
    {
        Query
            .Select(x => new UniversityPositionDto(x.Id, x.Name))
            .AsNoTracking();
    }
}
