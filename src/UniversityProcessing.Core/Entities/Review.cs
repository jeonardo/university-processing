namespace UniversityProcessing.Core.Entities;

public class Review : EntityBase
{
    public string? Content { get; private set; }
    public FilePath? File { get; private set; }
    public DateTime CreatedAt { get; } = DateTime.UtcNow;

    // Навигационные свойства
    public DiplomaProject DiplomaProject { get; private set; }
    public Employee Supervisor { get; private set; }

    public Review(
        DiplomaProject diplomaProject,
        Employee supervisor,
        string? content = null,
        FilePath? file = null)
    {
        if (diplomaProject.Supervisor.Id != supervisor.Id)
        {
            throw new ArgumentException("Employee is not supervisor of this project");
        }

        DiplomaProject = diplomaProject;
        Supervisor = supervisor;
        Content = content;
        File = file;
    }
}
