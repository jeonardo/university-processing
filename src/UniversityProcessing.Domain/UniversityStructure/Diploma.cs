using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UniversityProcessing.Domain.Bases;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.Domain.UniversityStructure.Enums;

namespace UniversityProcessing.Domain.UniversityStructure;

public sealed class Diploma : BaseEntity
{
    [StringLength(50, MinimumLength = 1)]
    public string Title { get; private set; } = null!;

    [Range(0, 10)]
    public int? Grade { get; private set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public DiplomaStatusId StatusId { get; private set; } = DiplomaStatusId.Created;

    public Guid? DiplomaPeriodId { get; private set; }

    public DiplomaPeriod? DiplomaPeriod { get; private set; }
    public Guid? StudentId { get; private set; }

    public Guid? SupervisorId { get; private set; }

    public ICollection<User> Users { get; private set; } = [];

    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    private Diploma()
    {
    }

    public static Diploma Create(string title, Guid? diplomaPeriodId = null, Guid? studentId = null, Guid? supervisorId = null)
    {
        return new Diploma
        {
            Title = title,
            DiplomaPeriodId = diplomaPeriodId,
            StudentId = studentId,
            SupervisorId = supervisorId
        };
    }
}
