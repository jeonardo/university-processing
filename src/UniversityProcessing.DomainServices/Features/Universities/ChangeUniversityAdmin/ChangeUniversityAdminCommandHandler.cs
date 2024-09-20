using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.Universities.ChangeUniversityAdmin;

internal sealed class ChangeUniversityAdminCommandHandler(IEfRepository<University> repository) : IRequestHandler<ChangeUniversityAdminCommandRequest>
{
    public async Task Handle(ChangeUniversityAdminCommandRequest request, CancellationToken cancellationToken)
    {
        var university = await repository.GetByIdRequiredAsync(request.UniversityId, cancellationToken);

        university.Update(adminId: request.UserId);

        await repository.UpdateAsync(university, cancellationToken);
    }
}
