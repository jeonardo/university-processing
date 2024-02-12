using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Domain.API;

namespace UniversityProcessing.API.Endpoints.Authenticate
{
    public record LoginRequest([Required][MinLength(1)] string UserName,
                               [Required][MinLength(4)] string Password) : BaseRequest;
}
