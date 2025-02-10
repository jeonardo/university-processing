namespace UniversityProcessing.API.Endpoints.Identity.Info;

public sealed class GroupDto(string number, DateTime startDate, DateTime endDate)
{
    public string Number { get; set; } = number;
    public DateTime StartDate { get; set; } = startDate;
    public DateTime EndDate { get; set; } = endDate;
}
