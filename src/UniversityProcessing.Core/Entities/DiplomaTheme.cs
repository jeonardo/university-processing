namespace UniversityProcessing.Core.Entities;

public class DiplomaTheme : EntityBase
{
    private readonly List<DiplomaProject> _diplomaProjects = new();
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public bool IsApprovedByDepartment { get; private set; }
    public bool IsMandatory { get; private set; }

    // Навигационные свойства
    public Employee? Supervisor { get; private set; }
    public IReadOnlyCollection<DiplomaProject> DiplomaProjects => _diplomaProjects.AsReadOnly();

    public DiplomaTheme(
        string title,
        string? description = null,
        Employee? supervisor = null)
    {
        Title = title;
        Description = description;
        Supervisor = supervisor;
    }

    // Бизнес-методы
    public void ApproveByDepartment(bool isMandatory = false)
    {
        IsApprovedByDepartment = true;
        IsMandatory = isMandatory;
    }
}
