using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using UniversityProcessing.API.Utils;
using UniversityProcessing.Domain.DTOs;
using UniversityProcessing.Domain.Identity;

namespace UniversityProcessing.API.AuthenticateEndpoints
{
    [ApiController]
    [Route("api/[controller]")]
    public class IdentityController(ITokenClaimsService tokenClaimsService,
                                    IUserStore<UserEntity> userStore,
                                    SignInManager<UserEntity> signInManager,
                                    UserManager<UserEntity> userManager,
                                    AuthOptions authOptions,
                                    TokenValidationParameters tokenValidationParameters) : ControllerBase
    {
        [ValidateModel]
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request, CancellationToken cancellationToken = default)
        {
            var response = new LoginResponse(request.CorrelationId);

            var signInResult = await signInManager.PasswordSignInAsync(request.UserName, request.Password, false, false);

            if (!signInResult.Succeeded)
                return Unauthorized(TypedResults.Problem(signInResult.ToString(), statusCode: StatusCodes.Status401Unauthorized));

            var userEntity = await userManager.FindByNameAsync(request.UserName);

            if (userEntity is null)
                return NotFound($"User with email = {request.UserName} not found!");

            var token = GenerateAccessToken(userEntity);

            userEntity.RefreshToken = token.RefreshValue;
            userEntity.RefreshTokenExpiryTimeUTC = token.RefreshExpiration;

            var identityResult = await userManager.UpdateAsync(userEntity);

            if (!identityResult.Succeeded)
                return Unauthorized(identityResult.Errors);

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
        public async Task<ActionResult<RefreshResponse>> RefreshAsync([FromBody] RefreshRequest request, CancellationToken cancellationToken = default)
        {
            var response = new RefreshResponse(request.CorrelationId);

            var result = await tokenClaimsService.RefreshAsync(request.Value, request.RefreshValue, cancellationToken);

            if(result.IsSuccess) 
            return result;
        }
    }
}
