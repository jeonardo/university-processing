using System.ComponentModel.DataAnnotations;
using UniversityProcessing.GenericSubdomain.Identity;
using UniversityProcessing.GenericSubdomain.Validation;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace UniversityProcessing.Domain;
// TODO check is pragma effective

public sealed class Notification : BaseEntity
{
    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string Title { get; private set; }

    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string Message { get; private set; }

    public bool IsRead { get; private set; }
    public Guid UserId { get; private set; }

    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    private Notification()
    {
    }

    public static Notification Create(string title, string message, Guid userId)
    {
        return new Notification
        {
            Title = title,
            Message = message,
            UserId = userId
        };
    }
}
