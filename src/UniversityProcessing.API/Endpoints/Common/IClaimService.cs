using System.Security.Claims;
using UniversityProcessing.Domain.Users;

namespace UniversityProcessing.API.Endpoints.Common;

public interface IClaimService
{
    Task<Claim[]> GetClaims(User user);
}
