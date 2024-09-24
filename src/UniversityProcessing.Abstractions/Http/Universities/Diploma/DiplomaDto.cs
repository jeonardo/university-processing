namespace UniversityProcessing.Abstractions.Http.Universities.Diploma;

public sealed class DiplomaDto(Guid id, string title, int? grade, DiplomaStatusDto status)
{
    public Guid Id { get; set; } = id;

    public string Title { get; set; } = title;

    public int? Grade { get; set; } = grade;

    public DiplomaStatusDto Status { get; set; } = status;
}
