using Ardalis.Specification;
using MediatR;
using UniversityProcessing.Abstractions.Http.Identity.RegisterEmployee;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.Identity.RegisterEmployee.GetRegisterEmployeeAvailableUniversities;

internal sealed class GetRegisterEmployeeAvailableUniversitiesQueryHandler(IEfRepository<University> repository)
    : IRequestHandler<GetRegisterEmployeeAvailableUniversitiesQueryRequest, GetRegisterEmployeeAvailableUniversitiesQueryResponse>
{
    public async Task<GetRegisterEmployeeAvailableUniversitiesQueryResponse> Handle(
        GetRegisterEmployeeAvailableUniversitiesQueryRequest request,
        CancellationToken cancellationToken)
    {
        var specification = new GetRegisterEmployeeAvailableUniversitiesSpecification(request.Name);
        var entities = await repository.ListAsync(specification, cancellationToken);
        return new GetRegisterEmployeeAvailableUniversitiesQueryResponse(entities.ToArray());
    }

    private sealed class GetRegisterEmployeeAvailableUniversitiesSpecification : Specification<University, RegisterEmployeeUniversityDto>
    {
        public GetRegisterEmployeeAvailableUniversitiesSpecification(string name)
        {
            //TODO add search field, fix search by short name
            Query
                .Select(x => new RegisterEmployeeUniversityDto(x.Id, x.ShortName))
                .AsNoTracking()
                .Where(x => x.Name.Contains(name) || x.ShortName.Contains(name))
                .Take(10);
        }
    }
}
