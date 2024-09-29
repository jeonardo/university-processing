namespace UniversityProcessing.Abstractions.Http.Identity.RegisterStudent;

public sealed class GetRegisterStudentAvailableGroupsResponseDto(string[] groupNumbers)
{
    public string[] GroupNumbers { get; set; } = groupNumbers;
}
