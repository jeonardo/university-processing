using UniversityProcessing.API.Endpoints.Registration.Common.Forms;
using UniversityProcessing.Domain.Users;

namespace UniversityProcessing.API.Endpoints.Registration.Common;

internal interface IRegistrationService
{
    Task<long> Register(IRegistrationForm registrationForm, UserRoleType role, CancellationToken cancellationToken);
    Task Verify(string userName);
}
