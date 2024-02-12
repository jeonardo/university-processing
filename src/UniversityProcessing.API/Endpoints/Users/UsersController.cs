using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.Infrastructure.Repositories;

namespace UniversityProcessing.API.Endpoints.UserEndpoints
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(IRepository<UserEntity> repository) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            repository.GetBySpecAsync(x=>x.);
            return Ok();
        }
    }
}
