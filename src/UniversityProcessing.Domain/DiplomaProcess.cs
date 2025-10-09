using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Domain.Events;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Utils.Identity;
using UniversityProcessing.Utils.Validation;

namespace UniversityProcessing.Domain;

public class DiplomaProcess : BaseEntity
{
    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string Name { get; private set; } = null!;

    public DateTime? PossibleFrom { get; private set; }
    public DateTime? PossibleTo { get; private set; }
    public long PeriodId { get; private set; }
    public virtual Period Period { get; private set; } = null!;
    public virtual ICollection<ProjectTitle> RequiredProjectTitles { get; private set; } = [];
    public virtual ICollection<Group> Groups { get; private set; } = [];
    public virtual ICollection<Committee> Committees { get; private set; } = [];
    public virtual ICollection<Teacher> Teachers { get; private set; } = [];
    public virtual ICollection<DefenseSession> DefenseSessions { get; private set; } = [];

    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    private DiplomaProcess()
    {
    }

    public static DiplomaProcess Fake(long id)
    {
        return new DiplomaProcess
        {
            Id = id
        };
    }

    public static DiplomaProcess Create(string name, long periodId)
    {
        return new DiplomaProcess
        {
            Name = name,
            PeriodId = periodId
        };
    }

    public void AddGroup(Group group)
    {
        Groups.Add(group);
        RegisterDomainEvent(
            new DiplomaProcessGroupAddedEvent
            {
                GroupId = group.Id,
                DiplomaProcessId = Id
            });
    }
}
