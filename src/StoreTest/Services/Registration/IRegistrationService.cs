using StoreTest.Services.Registration.Forms;

namespace StoreTest.Services.Registration;

internal interface IRegistrationService
{
    Task Register(IRegistrationForm registrationForm, UserRoleType role, CancellationToken cancellationToken);
    Task Verify(string userName);
}
