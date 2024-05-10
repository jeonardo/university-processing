using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Features.Specialties.Create.Contracts;
using UniversityProcessing.GenericSubdomain.Exceptions;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.Specialties.Create;

internal sealed class SpecialtyCreateCommandHandler(IEfRepository<Specialty> specialtyRepository, IEfRepository<Faculty> facultyRepository)
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