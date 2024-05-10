namespace UniversityProcessing.Abstractions.Http.Universities.Diploma;

public sealed class DiplomaDto
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public int? Grade { get; set; }

    public DiplomaStatusIdDto StatusId { get; set; }

    public DiplomaDto(Guid id, string title, int? grade, DiplomaStatusIdDto statusId)
    {
        Id = id;
        Title = title;
        Grade = grade;
        StatusId = statusId;
    }
}