namespace UniversityProcessing.API.Endpoints.Registration.Common.Forms;

public interface IDeaneryRegistrationForm : IRegistrationForm
{
    long FacultyId { get; set; }
    long UniversityPositionId { get; set; }
}
