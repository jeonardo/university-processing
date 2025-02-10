using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UniversityProcessing.GenericSubdomain.Identity;
using UniversityProcessing.GenericSubdomain.Validation;

namespace UniversityProcessing.Domain;

public sealed class Diploma : BaseEntity
{
    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string Title { get; private set; } = null!;

    [Range(0, 10)]
    public int? Grade { get; private set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public DiplomaStatus Status { get; private set; } = DiplomaStatus.Created;

    public Guid? DiplomaProcessId { get; private set; }

    public DiplomaProcess? DiplomaProcess { get; private set; }
    public Guid? StudentId { get; private set; }
    public Guid? SupervisorId { get; private set; }

    public ICollection<User> Users { get; private set; } = [];

    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    private Diploma()
    {
    }

    public static Diploma Create(string title, Guid? diplomaProcessId = null, Guid? studentId = null, Guid? supervisorId = null)
    {
        return new Diploma
        {
            Title = title,
            DiplomaProcessId = diplomaProcessId,
            StudentId = studentId,
            SupervisorId = supervisorId
        };
    }
}
