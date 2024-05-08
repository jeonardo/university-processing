using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using UniversityProcessing.Domain.Bases;

namespace UniversityProcessing.Domain.UniversityStructure;

public sealed class UniversityPosition : BaseEntity
{
    [StringLength(50, MinimumLength = 1)]
    public string Name { get; private set; } = null!;

    public Guid UniversityId { get; private set; }

    public University University { get; private set; } = null!;

    public UniversityPosition(string name, University university)
    {
        Name = Guard.Against.NullOrWhiteSpace(name);
        UniversityId = Guard.Against.Null(university).Id;
        University = Guard.Against.Null(university);
    }

    //Parameterless constructor used by EF Core
    private UniversityPosition()
    {
    }
}