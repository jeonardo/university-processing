using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using UniversityProcessing.Domain.Bases;
using UniversityProcessing.Domain.Identity;

namespace UniversityProcessing.Domain.UniversityStructure;

public sealed class Specialty : BaseEntity
{
    [StringLength(50, MinimumLength = 1)]
    public string Name { get; private set; } = null!;

    [StringLength(25, MinimumLength = 1)]
    public string ShortName { get; private set; } = null!;

    [StringLength(12, MinimumLength = 12)]
    public string Code { get; private set; } = null!;

    public Guid FacultyId { get; private set; }

    public Faculty Faculty { get; private set; } = null!;

    public ICollection<Group> Groups { get; private set; } = [];

    public ICollection<User> Students { get; private set; } = [];

    public Specialty(string name, string shortName, Faculty faculty, string code)
    {
        Name = Guard.Against.NullOrWhiteSpace(name);
        ShortName = Guard.Against.NullOrWhiteSpace(shortName);
        Code = Guard.Against.NullOrWhiteSpace(code);
        FacultyId = Guard.Against.Null(faculty).Id;
        Faculty = Guard.Against.Null(faculty);
    }

    //Parameterless constructor used by EF Core
    private Specialty()
    {
    }
}