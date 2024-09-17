using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.Departments.Create;

internal sealed class CreateDepartmentCommandHandler(IEfRepository<Department> departmentRepository)
    : IRequestHandler<CreateDepartmentCommandRequest, CreateDepartmentCommandResponse>
{
    public async Task<CreateDepartmentCommandResponse> Handle(CreateDepartmentCommandRequest request, CancellationToken cancellationToken)
    {
        var newEntity = Department.Create(request.Name, request.ShortName, request.FacultyId);

        await departmentRepository.AddAsync(newEntity, cancellationToken);

        return new CreateDepartmentCommandResponse(newEntity.Id);
    }
}
