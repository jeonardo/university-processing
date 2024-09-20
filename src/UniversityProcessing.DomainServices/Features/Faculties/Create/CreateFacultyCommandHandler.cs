using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.Faculties.Create;

internal sealed class CreateFacultyCommandHandler(IEfRepository<Faculty> facultyRepository)
    : IRequestHandler<CreateFacultyCommandRequest, CreateFacultyCommandResponse>
{
    public async Task<CreateFacultyCommandResponse> Handle(CreateFacultyCommandRequest request, CancellationToken cancellationToken)
    {
        var newEntity = Faculty.Create(request.Name, request.ShortName, request.UniversityId);

        await facultyRepository.AddAsync(newEntity, cancellationToken);

        return new CreateFacultyCommandResponse(newEntity.Id);
    }
}
