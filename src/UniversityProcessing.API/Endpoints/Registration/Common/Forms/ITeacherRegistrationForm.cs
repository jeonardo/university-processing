namespace UniversityProcessing.API.Endpoints.Registration.Common.Forms;

public interface ITeacherRegistrationForm : IRegistrationForm
{
    public long DepartmentId { get; set; }

    public long UniversityPositionId { get; set; }
}
