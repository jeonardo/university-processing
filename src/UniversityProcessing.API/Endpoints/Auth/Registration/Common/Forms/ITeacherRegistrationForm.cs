namespace UniversityProcessing.API.Endpoints.Auth.Registration.Common.Forms;

public interface ITeacherRegistrationForm : IRegistrationForm
{
    public Guid DepartmentId { get; set; }

    public Guid UniversityPositionId { get; set; }
}
