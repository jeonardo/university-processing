using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Auth.Refresh;

public sealed class RequestDto(string accessToken, string refreshToken)
{
    [Required]
    public string AccessToken { get; set; } = accessToken;

    [Required]
    public string RefreshToken { get; set; } = refreshToken;
}
