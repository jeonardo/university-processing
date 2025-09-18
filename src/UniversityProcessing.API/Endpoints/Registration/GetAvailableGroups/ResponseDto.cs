namespace UniversityProcessing.API.Endpoints.Registration.GetAvailableGroups;

public sealed class ResponseDto(string[] groupNumbers)
{
    public string[] GroupNumbers { get; set; } = groupNumbers;
}
