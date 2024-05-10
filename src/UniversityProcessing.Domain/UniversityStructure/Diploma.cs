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

    public Guid StudentId { get; private set; }
    public User Student { get; private set; } = null!;

    public Guid? SupervisorId { get; set; }

    public User? Supervisor { get; set; }

    public Diploma(string title, User student)
    {
        Title = Guard.Against.NullOrWhiteSpace(title);
        StudentId = Guard.Against.Null(student).Id;
        Student = Guard.Against.Null(student);
    }

    //Parameterless constructor used by EF Core
    private Diploma()
    {
    }
}