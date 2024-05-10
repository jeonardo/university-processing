using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.Abstractions.Http.Universities.University;

public sealed class UniversityDeleteRequestDto
{
    [NotDefault]
    public Guid Id { get; set; }
}