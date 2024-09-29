namespace UniversityProcessing.Abstractions.Http.Identity.RegisterEmployee;

public sealed class RegisterEmployeeUniversityPositionDto(Guid id, string name)
{
    public Guid Id { get; set; } = id;
    public string Name { get; set; } = name;
}
