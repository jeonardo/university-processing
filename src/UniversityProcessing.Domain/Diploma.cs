using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Utils.Identity;
using UniversityProcessing.Utils.Validation;

namespace UniversityProcessing.Domain;

public class Diploma : BaseEntity
{
    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string? Title { get; private set; }

    [Range(0, 10)]
    public int? Grade { get; private set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public DiplomaStatus Status { get; private set; } = DiplomaStatus.Created;

    public long StudentId { get; private set; }
    public virtual Student Student { get; private set; } = null!;
    public long? SupervisorId { get; private set; }

    public virtual Teacher? Supervisor { get; private set; }

    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    private Diploma()
    {
    }

    public static Diploma Create(long studentId, long? supervisorId = null)
    {
        return new Diploma
        {
            StudentId = studentId,
            SupervisorId = supervisorId
        };
    }
}
