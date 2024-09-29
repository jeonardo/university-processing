namespace UniversityProcessing.Abstractions.Http.Identity.RegisterStudent;

public sealed class RegisterStudentGroupDto(string number)
{
    public string Number { get; set; } = number;
}
