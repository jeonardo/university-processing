namespace UniversityProcessing.API.Endpoints.Auth.Registration.GetAvailableGroups;

public sealed class GetAvailableGroupsResponseDto(string[] groupNumbers)
{
    public string[] GroupNumbers { get; set; } = groupNumbers;
}
