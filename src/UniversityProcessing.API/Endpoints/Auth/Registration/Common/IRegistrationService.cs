using UniversityProcessing.API.Endpoints.Auth.Registration.Common.Forms;
using UniversityProcessing.Domain.Users;

namespace UniversityProcessing.API.Endpoints.Auth.Registration.Common;

internal interface IRegistrationService
{
    Task<Guid> Register(IRegistrationForm registrationForm, UserRoleType role, CancellationToken cancellationToken);
    Task Verify(string userName);
}
