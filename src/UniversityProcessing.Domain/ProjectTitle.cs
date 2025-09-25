using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Utils.Identity;
using UniversityProcessing.Utils.Validation;

namespace UniversityProcessing.Domain;

public sealed class ProjectTitle : BaseEntity
{
    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string Title { get; set; } = null!;

    public Guid CreatorId { get; set; }

    public Guid? ActorId { get; set; }

    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    private ProjectTitle()
    {
    }

    public static ProjectTitle Create(string title, Guid creatorId)
    {
        return new ProjectTitle
        {
            Title = title,
            CreatorId = creatorId
        };
    }
}
