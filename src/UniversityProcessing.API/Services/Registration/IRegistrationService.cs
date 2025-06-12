using UniversityProcessing.API.Services.Registration.Forms;
using UniversityProcessing.Domain;

namespace UniversityProcessing.API.Services.Registration;

internal interface IRegistrationService
{
    Task Register(IRegistrationForm registrationForm, UserRoleType role, CancellationToken cancellationToken);
    Task Verify(string userName);
}
