using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using UniversityProcessing.API.Utils;
using UniversityProcessing.Domain.DTOs;
using UniversityProcessing.Domain.Identity;

namespace UniversityProcessing.API.Endpoints.Authenticate
{
    [ApiController]
    [Route("api/[controller]")]
    public class IdentityController(ITokenClaimsService tokenClaimsService,
                                    IUserStore<UserEntity> userStore,
                                    UserManager<UserEntity> userManager) : ControllerBase
    {
        [ValidateModel]
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request, CancellationToken cancellationToken = default)
        {
            var token = await tokenClaimsService.GetTokenAsync(request.UserName, request.Password, cancellationToken);
            return Ok(token);
        }

        [ValidateModel]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest request, CancellationToken cancellationToken = default)
        {
            var user = new UserEntity();
            var emailStore = (IUserEmailStore<UserEntity>)userStore;
            await userStore.SetUserNameAsync(user, request.UserName, CancellationToken.None);
            await emailStore.SetEmailAsync(user, request.UserName, CancellationToken.None);
            var result = await userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok();
        }

        [ValidateModel]
        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshAsync([FromBody] RefreshRequest request, CancellationToken cancellationToken = default)
        {
            var token = await tokenClaimsService.RefreshTokenAsync(request.Value,
                                                              request.RefreshValue,
                                                              cancellationToken);
            return Ok(new RefreshResponse(request.CorrelationId, token));
        }
    }
}
