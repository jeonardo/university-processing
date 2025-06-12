namespace UniversityProcessing.API.Services.Registration.Forms;

public interface IStudentRegistrationForm : IRegistrationForm
{
    public string GroupNumber { get; set; }
}
