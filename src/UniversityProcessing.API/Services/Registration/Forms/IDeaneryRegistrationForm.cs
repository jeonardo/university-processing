namespace UniversityProcessing.API.Services.Registration.Forms;

public interface IDeaneryRegistrationForm : IRegistrationForm
{
    Guid FacultyId { get; set; }
    Guid UniversityPositionId { get; set; }
}
