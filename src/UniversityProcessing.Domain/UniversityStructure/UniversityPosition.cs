using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Domain.Bases;

namespace UniversityProcessing.Domain.UniversityStructure;

public sealed class UniversityPosition : BaseEntity
{
    [StringLength(50, MinimumLength = 1)]
    public string Name { get; private set; } = null!;

    public UniversityPosition(string name)
    {
        Name = name;
    }

    //Parameterless constructor used by EF Core
    private UniversityPosition()
    {
    }
}
