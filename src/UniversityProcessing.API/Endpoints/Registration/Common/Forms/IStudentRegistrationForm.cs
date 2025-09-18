namespace UniversityProcessing.API.Endpoints.Registration.Common.Forms;

public interface IStudentRegistrationForm : IRegistrationForm
{
    public string GroupNumber { get; set; }
}
