namespace UniversityProcessing.API.Endpoints.Auth.Registration.Common.Forms;

public interface IStudentRegistrationForm : IRegistrationForm
{
    public string GroupNumber { get; set; }
}
