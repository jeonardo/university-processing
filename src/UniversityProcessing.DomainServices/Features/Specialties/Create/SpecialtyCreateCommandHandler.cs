using Ardalis.SharedKernel;
using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Exceptions;
using UniversityProcessing.DomainServices.Features.Specialties.Create.Contracts;

namespace UniversityProcessing.DomainServices.Features.Specialties.Create;

internal sealed class SpecialtyCreateCommandHandler(IRepository<Specialty> specialtyRepository, IRepository<Faculty> facultyRepository)
    : IRequestHandler<SpecialtyCreateCommandRequest, SpecialtyCreateCommandResponse>
{
    public async Task<SpecialtyCreateCommandResponse> Handle(SpecialtyCreateCommandRequest request, CancellationToken cancellationToken)
    {
        var faculty = await facultyRepository.GetByIdAsync(request.FacultyId, cancellationToken)
            ?? throw new NotFoundException($"{nameof(Faculty)} with id = {request.FacultyId} not found");

        var newEntity = new Specialty(request.Name, request.ShortName, faculty, request.Code);

        await specialtyRepository.AddAsync(newEntity, cancellationToken);

        var resultCode = await specialtyRepository.SaveChangesAsync(cancellationToken);

        if (resultCode is not 1)
        {
            throw new ConflictException($"{nameof(SpecialtyCreateCommandRequest)} failed");
        }

        return new SpecialtyCreateCommandResponse(newEntity.Id);
    }
}