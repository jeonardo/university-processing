using Ardalis.SharedKernel;
using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Exceptions;
using UniversityProcessing.DomainServices.Features.Faculties.Create.Contracts;

namespace UniversityProcessing.DomainServices.Features.Faculties.Create;

internal sealed class FacultyCreateCommandHandler(IRepository<University> universityRepository, IRepository<Faculty> facultyRepository)
    : IRequestHandler<FacultyCreateCommandRequest, FacultyCreateCommandResponse>
{
    public async Task<FacultyCreateCommandResponse> Handle(FacultyCreateCommandRequest request, CancellationToken cancellationToken)
    {
        var university = await universityRepository.GetByIdAsync(request.UniversityId, cancellationToken)
            ?? throw new NotFoundException($"{nameof(University)} with id = {request.UniversityId} not found");

        var newEntity = new Faculty(request.Name, request.ShortName, university);

        await facultyRepository.AddAsync(newEntity, cancellationToken);

        var resultCode = await facultyRepository.SaveChangesAsync(cancellationToken);

        if (resultCode is not 1)
        {
            throw new ConflictException($"{nameof(FacultyCreateCommandRequest)} failed");
        }

        return new FacultyCreateCommandResponse(newEntity.Id);
    }
}