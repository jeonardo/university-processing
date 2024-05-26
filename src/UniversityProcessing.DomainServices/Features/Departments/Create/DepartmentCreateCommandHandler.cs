using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Features.Departments.Create.Contracts;
using UniversityProcessing.GenericSubdomain.Middlewares.Exceptions;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.Departments.Create;

internal sealed class DepartmentCreateCommandHandler(IEfRepository<Department> departmentRepository, IEfRepository<Faculty> facultyRepository)
    : IRequestHandler<DepartmentCreateCommandRequest, DepartmentCreateCommandResponse>
{
    public async Task<DepartmentCreateCommandResponse> Handle(DepartmentCreateCommandRequest request, CancellationToken cancellationToken)
    {
        var faculty = await facultyRepository.GetByIdAsync(request.FacultyId, cancellationToken)
            ?? throw new NotFoundException($"{nameof(Faculty)} with id = {request.FacultyId} not found");

        var newEntity = new Department(request.Name, request.ShortName, faculty);

        await departmentRepository.AddAsync(newEntity, cancellationToken);

        var resultCode = await departmentRepository.SaveChangesAsync(cancellationToken);

        if (resultCode is not 1)
        {
            throw new ConflictException($"{nameof(DepartmentCreateCommandRequest)} failed");
        }

        return new DepartmentCreateCommandResponse(newEntity.Id);
    }
}