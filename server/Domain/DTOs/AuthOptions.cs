using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace UniversityProcessing.API.Domain.DTOs
{
    public record AuthOptions(bool ValidateIssuer = false,
                              bool ValidateAudience = false,
                              bool ValidateIssuerSigningKey = false,
                              string ValidIssuer = "",
                              string ValidAudience = "",
                              string Key = "",
                              int LifetimeMinutes = 0,
                              int RefreshLifetimeMinutes = 0);
}
