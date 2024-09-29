using Ardalis.Specification;
using MediatR;
using UniversityProcessing.Abstractions.Http.Identity.RegisterEmployee;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.Identity.RegisterEmployee.GetRegisterEmployeeAvailableUniversityPositions;

internal sealed class GetRegisterEmployeeAvailableUniversityPositionsQueryHandler(IEfReadRepository<UniversityPosition> repository)
    : IRequestHandler<GetRegisterEmployeeAvailableUniversityPositionsQueryRequest, GetRegisterEmployeeAvailableUniversityPositionsQueryResponse>
{
    public async Task<GetRegisterEmployeeAvailableUniversityPositionsQueryResponse> Handle(
        GetRegisterEmployeeAvailableUniversityPositionsQueryRequest request,
        CancellationToken cancellationToken)
    {
        var specification = new GetRegisterEmployeeAvailableUniversityPositionsQuerySpecification();
        var entities = await repository.ListAsync(specification, cancellationToken);
        return new GetRegisterEmployeeAvailableUniversityPositionsQueryResponse(entities.ToArray());
    }

    private sealed class GetRegisterEmployeeAvailableUniversityPositionsQuerySpecification : Specification<UniversityPosition, RegisterEmployeeUniversityPositionDto>
    {
        public GetRegisterEmployeeAvailableUniversityPositionsQuerySpecification()
        {
            Query
                .Select(x => new RegisterEmployeeUniversityPositionDto(x.Id, x.Name))
                .AsNoTracking();
        }
    }
}
