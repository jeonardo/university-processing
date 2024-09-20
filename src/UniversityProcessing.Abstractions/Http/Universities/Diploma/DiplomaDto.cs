namespace UniversityProcessing.Abstractions.Http.Universities.Diploma;

public sealed class DiplomaDto
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public int? Grade { get; set; }

    public DiplomaStatusDto Status { get; set; }

    public DiplomaDto(Guid id, string title, int? grade, DiplomaStatusDto status)
    {
        Id = id;
        Title = title;
        Grade = grade;
        Status = status;
    }
}
