using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Ardalis.GuardClauses;
using UniversityProcessing.Domain.Bases;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.Domain.UniversityStructure.Enums;

namespace UniversityProcessing.Domain.UniversityStructure;

public sealed class Diploma : BaseEntity
{
    [StringLength(50, MinimumLength = 1)]
    public string Title { get; private set; } = null!;

    [Range(0, 10)]
    public int? Grade { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public DiplomaStatusId StatusId { get; private set; } = DiplomaStatusId.Created;

    public Guid DiplomaPeriodId { get; private set; }

    public DiplomaPeriod DiplomaPeriod { get; private set; } = null!;
    public Guid StudentId { get; private set; }

    public Guid? SupervisorId { get; set; }

    public ICollection<User> Users { get; private set; } = [];

    public Diploma(DiplomaPeriod diplomaPeriod, string title, User student)
    {
        Title = Guard.Against.NullOrWhiteSpace(title);
        StudentId = Guard.Against.Null(student).Id;
        DiplomaPeriodId = Guard.Against.Null(diplomaPeriod).Id;
        DiplomaPeriod = Guard.Against.Null(diplomaPeriod);
    }

    //Parameterless constructor used by EF Core
    private Diploma()
    {
    }
}