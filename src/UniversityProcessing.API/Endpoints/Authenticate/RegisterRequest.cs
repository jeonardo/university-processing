using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Authenticate
{
    public record RegisterRequest([Required][MinLength(1)] string UserName,
                                  [Required][MinLength(4)] string Password);
}
