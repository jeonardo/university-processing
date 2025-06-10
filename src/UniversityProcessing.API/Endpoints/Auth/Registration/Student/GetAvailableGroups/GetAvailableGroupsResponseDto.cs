namespace UniversityProcessing.API.Endpoints.Auth.Registration.Student.GetAvailableGroups;

public sealed class GetAvailableGroupsResponseDto(string[] groupNumbers)
{
    public string[] GroupNumbers { get; set; } = groupNumbers;
}
