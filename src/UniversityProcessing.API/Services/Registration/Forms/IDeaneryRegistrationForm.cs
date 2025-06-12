namespace UniversityProcessing.API.Services.Registration.Forms;

public interface IDeaneryRegistrationForm : IRegistrationForm
{
    public Guid FacultyId { get; set; }
}
