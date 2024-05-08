namespace UniversityProcessing.Abstractions.Http.Universities;

public sealed class DepartmentCreateResponseDto(Guid id)
{
    public Guid Id { get; set; } = id;
}