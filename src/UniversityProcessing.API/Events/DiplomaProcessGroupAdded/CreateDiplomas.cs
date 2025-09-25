using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.Domain;
using UniversityProcessing.Domain.Events;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;

namespace UniversityProcessing.API.Events.DiplomaProcessGroupAdded;

internal sealed class CreateDiplomas(IEfRepository<Student> studentRepository, IEfRepository<Diploma> diplomaRepository)
    : INotificationHandler<DiplomaProcessGroupAddedEvent>
{
    public async Task Handle(DiplomaProcessGroupAddedEvent notification, CancellationToken cancellationToken)
    {
        var studentsFromGroupWithoutDiploma = await studentRepository.TypedDbContext
            .Where(x => x.GroupId == notification.GroupId && x.DiplomaId == null)
            .ToArrayAsync(cancellationToken);

        var newDiplomas = studentsFromGroupWithoutDiploma
            .Select(x => Diploma.Create(notification.DiplomaProcessId, x.Id))
            .ToArray();

        await diplomaRepository.AddRangeAsync(newDiplomas, cancellationToken);
    }
}
