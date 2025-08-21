namespace StoreTest.Services.Registration.Forms;

public interface ITeacherRegistrationForm : IRegistrationForm
{
    public Guid FacultyId { get; set; }

    public Guid DepartmentId { get; set; }

    public Guid UniversityPositionId { get; set; }
}
