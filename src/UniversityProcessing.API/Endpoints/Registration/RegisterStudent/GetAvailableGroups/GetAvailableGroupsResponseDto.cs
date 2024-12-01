namespace UniversityProcessing.API.Endpoints.Registration.RegisterStudent.GetAvailableGroups;

public sealed class GetAvailableGroupsResponseDto(string[] groupNumbers)
{
    public string[] GroupNumbers { get; set; } = groupNumbers;
}
