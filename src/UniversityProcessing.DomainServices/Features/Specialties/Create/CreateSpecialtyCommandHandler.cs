using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Middlewares.Exceptions;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.Specialties.Create;

internal sealed class CreateSpecialtyCommandHandler(IEfRepository<Specialty> specialtyRepository)
    : IRequestHandler<CreateSpecialtyCommandRequest, CreateSpecialtyCommandResponse>
{
    public async Task<CreateSpecialtyCommandResponse> Handle(CreateSpecialtyCommandRequest request, CancellationToken cancellationToken)
    {
        var newEntity = Specialty.Create(request.Name, request.ShortName, request.Code, request.FacultyId);

        await specialtyRepository.AddAsync(newEntity, cancellationToken);

        var resultCode = await specialtyRepository.SaveChangesAsync(cancellationToken);

        if (resultCode is not 1)
        {
            throw new ConflictException($"{nameof(CreateSpecialtyCommandRequest)} failed");
        }

        return new CreateSpecialtyCommandResponse(newEntity.Id);
    }
}
