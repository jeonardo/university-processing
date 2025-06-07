namespace UniversityProcessing.Core.Entities;

public class Student : User

{
    public int GraduationYear { get; private set; }

    public string? Group { get; private set; }

    // Навигационные свойства

    public DiplomaProject? DiplomaProject { get; private set; }

    public Guid? SpecialtyId { get; private set; }

    public Specialty? Specialty { get; private set; }

    // ... методы, специфичные для студента

    public Student(
        PersonalName name,
        Email email,
        string passwordHash,
        string group,
        int graduationYear)
        : base(name, email, passwordHash)
    {
        Group = group;
        GraduationYear = graduationYear;
    }

    // Бизнес-методы
    public void EnrollInSpecialty(Specialty specialty)
    {
        if (DiplomaProject != null)
        {
            throw new InvalidOperationException("Student already has diploma project");
        }

        Specialty = specialty;
    }

    public void StartDiplomaProject(Employee supervisor, DiplomaTheme theme)
    {
        if (Specialty == null)
        {
            throw new InvalidOperationException("Student not enrolled in specialty");
        }

        DiplomaProject = new DiplomaProject(this, supervisor, theme);
    }
}
