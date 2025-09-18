namespace UniversityProcessing.API.Endpoints.Registration.Common.Forms;

public interface IDeaneryRegistrationForm : IRegistrationForm
{
    Guid FacultyId { get; set; }
    Guid UniversityPositionId { get; set; }
}
