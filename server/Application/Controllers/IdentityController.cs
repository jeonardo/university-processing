using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using UniversityProcessing.API.Domain.DTOs;
using UniversityProcessing.API.Domain.Entities;

namespace UniversityProcessing.API.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IdentityController(IHttpContextAccessor httpContext,
                                    IUserStore<UserEntity> userStore,
                                    SignInManager<UserEntity> signInManager,
                                    UserManager<UserEntity> userManager,
                                    AuthOptions authOptions,
                                    TokenValidationParameters tokenValidationParameters) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request, CancellationToken cancellationToken = default)
        {
            var signInResult = await signInManager.PasswordSignInAsync(request.Email, request.Password, false, false);

            if (!signInResult.Succeeded)
                return Unauthorized(TypedResults.Problem(signInResult.ToString(), statusCode: StatusCodes.Status401Unauthorized));

            var userEntity = await userManager.FindByEmailAsync(request.Email);

            if (userEntity is null)
                return NotFound($"User with email = {request.Email} not found!");

            var token = GenerateAccessToken(userEntity);

            userEntity.RefreshToken = token.RefreshValue;
            userEntity.RefreshTokenExpiryTimeUTC = token.RefreshExpiration;

            var identityResult = await userManager.UpdateAsync(userEntity);

            if (!identityResult.Succeeded)
                return Unauthorized(identityResult.Errors);

            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest request, CancellationToken cancellationToken = default)
        {
            var user = new UserEntity();
            var emailStore = (IUserEmailStore<UserEntity>)userStore;
            await userStore.SetUserNameAsync(user, request.Email, CancellationToken.None);
            await emailStore.SetEmailAsync(user, request.Email, CancellationToken.None);
            var result = await userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok();
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshAsync([FromBody] Token request, CancellationToken cancellationToken = default)
        {
            var principal = GetClaimsPrincipalFromExpiredToken(request.Value);
            var email = principal.Claims.First(x => x.ValueType == "email_").Value;
            var userEntity = await userManager.FindByEmailAsync(email);

            if (userEntity is null)
                return NotFound($"User with email = {email} not found!");

            if (userEntity is null
                || userEntity.RefreshToken != request.RefreshValue
                || userEntity.RefreshTokenExpiryTimeUTC <= DateTime.UtcNow)
                return Unauthorized("Refresh token is invalid or expired!");

            var newToken = GenerateAccessToken(userEntity);

            userEntity.RefreshToken = newToken.RefreshValue;
            userEntity.RefreshTokenExpiryTimeUTC = newToken.RefreshExpiration;

            var identityResult = await userManager.UpdateAsync(userEntity);

            if (!identityResult.Succeeded)
                return Unauthorized(identityResult.Errors);

            return Ok(newToken);
        }

        private Token GenerateAccessToken(UserEntity userEntity)
        {
            var claims = new Claim[]
            {
                new ("id_", userEntity.Id.ToString()),
                new ("email_", userEntity.Email!),
                new ("userName_", userEntity.UserName!)
            };

            return GenerateAccessToken(claims);
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private Token GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var exp = DateTime.UtcNow.AddMinutes(authOptions.LifetimeMinutes);
            var refreshExp = DateTime.UtcNow.AddMinutes(authOptions.RefreshLifetimeMinutes);
            var jwt = new JwtSecurityToken(issuer: authOptions.ValidIssuer,
                                           audience: authOptions.ValidAudience,
                                           claims: claims,
                                           expires: exp,
                                           signingCredentials: new SigningCredentials(
                                               new SymmetricSecurityKey(Convert.FromBase64String(authOptions.Key)),
                                               SecurityAlgorithms.HmacSha256));
            return new Token(new JwtSecurityTokenHandler().WriteToken(jwt), exp, GenerateRefreshToken(), refreshExp);
        }

        private ClaimsPrincipal GetClaimsPrincipalFromExpiredToken(string token)
        {
            var principals = new JwtSecurityTokenHandler()
                .ValidateToken(token, tokenValidationParameters, out var securityToken);

            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(
                SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principals;
        }

        //routeGroup.MapGet("/confirmEmail", async Task<Results<ContentHttpResult, UnauthorizedHttpResult>>
        //    ([FromQuery] string userId, [FromQuery] string code, [FromQuery] string? changedEmail, [FromServices] IServiceProvider sp) =>
        //{
        //    var userManager = sp.GetRequiredService<UserManager<TUser>>();
        //    if (await userManager.FindByIdAsync(userId) is not { } user)
        //    {
        //        // We could respond with a 404 instead of a 401 like Identity UI, but that feels like unnecessary information.
        //        return TypedResults.Unauthorized();
        //    }

        //    try
        //    {
        //        code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
        //    }
        //    catch (FormatException)
        //    {
        //        return TypedResults.Unauthorized();
        //    }

        //    IdentityResult result;

        //    if (string.IsNullOrEmpty(changedEmail))
        //    {
        //        result = await userManager.ConfirmEmailAsync(user, code);
        //    }
        //    else
        //    {
        //        // As with Identity UI, email and user name are one and the same. So when we update the email,
        //        // we need to update the user name.
        //        result = await userManager.ChangeEmailAsync(user, changedEmail, code);

        //        if (result.Succeeded)
        //        {
        //            result = await userManager.SetUserNameAsync(user, changedEmail);
        //        }
        //    }

        //    if (!result.Succeeded)
        //    {
        //        return TypedResults.Unauthorized();
        //    }

        //    return TypedResults.Text("Thank you for confirming your email.");
        //})
        //.Add(endpointBuilder =>
        //{
        //    var finalPattern = ((RouteEndpointBuilder)endpointBuilder).RoutePattern.RawText;
        //    confirmEmailEndpointName = $"{nameof(MapIdentityApi)}-{finalPattern}";
        //    endpointBuilder.Metadata.Add(new EndpointNameMetadata(confirmEmailEndpointName));
        //});

        //routeGroup.MapPost("/resendConfirmationEmail", async Task<Ok>
        //    ([FromBody] ResendConfirmationEmailRequest resendRequest, HttpContext context, [FromServices] IServiceProvider sp) =>
        //{
        //    var userManager = sp.GetRequiredService<UserManager<TUser>>();
        //    if (await userManager.FindByEmailAsync(resendRequest.Email) is not { } user)
        //    {
        //        return TypedResults.Ok();
        //    }

        //    await SendConfirmationEmailAsync(user, userManager, context, resendRequest.Email);
        //    return TypedResults.Ok();
        //});

        //routeGroup.MapPost("/forgotPassword", async Task<Results<Ok, ValidationProblem>>
        //    ([FromBody] ForgotPasswordRequest resetRequest, [FromServices] IServiceProvider sp) =>
        //{
        //    var userManager = sp.GetRequiredService<UserManager<TUser>>();
        //    var user = await userManager.FindByEmailAsync(resetRequest.Email);

        //    if (user is not null && await userManager.IsEmailConfirmedAsync(user))
        //    {
        //        var code = await userManager.GeneratePasswordResetTokenAsync(user);
        //        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

        //        await emailSender.SendPasswordResetCodeAsync(user, resetRequest.Email, HtmlEncoder.Default.Encode(code));
        //    }

        //    // Don't reveal that the user does not exist or is not confirmed, so don't return a 200 if we would have
        //    // returned a 400 for an invalid code given a valid user email.
        //    return TypedResults.Ok();
        //});

        //routeGroup.MapPost("/resetPassword", async Task<Results<Ok, ValidationProblem>>
        //    ([FromBody] ResetPasswordRequest resetRequest, [FromServices] IServiceProvider sp) =>
        //{
        //    var userManager = sp.GetRequiredService<UserManager<TUser>>();

        //    var user = await userManager.FindByEmailAsync(resetRequest.Email);

        //    if (user is null || !(await userManager.IsEmailConfirmedAsync(user)))
        //    {
        //        // Don't reveal that the user does not exist or is not confirmed, so don't return a 200 if we would have
        //        // returned a 400 for an invalid code given a valid user email.
        //        return CreateValidationProblem(IdentityResult.Failed(userManager.ErrorDescriber.InvalidToken()));
        //    }

        //    IdentityResult result;
        //    try
        //    {
        //        var code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(resetRequest.ResetCode));
        //        result = await userManager.ResetPasswordAsync(user, code, resetRequest.NewPassword);
        //    }
        //    catch (FormatException)
        //    {
        //        result = IdentityResult.Failed(userManager.ErrorDescriber.InvalidToken());
        //    }

        //    if (!result.Succeeded)
        //    {
        //        return CreateValidationProblem(result);
        //    }

        //    return TypedResults.Ok();
        //});

        //var accountGroup = routeGroup.MapGroup("/manage").RequireAuthorization();

        //accountGroup.MapPost("/2fa", async Task<Results<Ok<TwoFactorResponse>, ValidationProblem, NotFound>>
        //    (ClaimsPrincipal claimsPrincipal, [FromBody] TwoFactorRequest tfaRequest, [FromServices] IServiceProvider sp) =>
        //{
        //    var signInManager = sp.GetRequiredService<SignInManager<TUser>>();
        //    var userManager = signInManager.UserManager;
        //    if (await userManager.GetUserAsync(claimsPrincipal) is not { } user)
        //    {
        //        return TypedResults.NotFound();
        //    }

        //    if (tfaRequest.Enable == true)
        //    {
        //        if (tfaRequest.ResetSharedKey)
        //        {
        //            return CreateValidationProblem("CannotResetSharedKeyAndEnable",
        //                "Resetting the 2fa shared key must disable 2fa until a 2fa token based on the new shared key is validated.");
        //        }
        //        else if (string.IsNullOrEmpty(tfaRequest.TwoFactorCode))
        //        {
        //            return CreateValidationProblem("RequiresTwoFactor",
        //                "No 2fa token was provided by the request. A valid 2fa token is required to enable 2fa.");
        //        }
        //        else if (!await userManager.VerifyTwoFactorTokenAsync(user, userManager.Options.Tokens.AuthenticatorTokenProvider, tfaRequest.TwoFactorCode))
        //        {
        //            return CreateValidationProblem("InvalidTwoFactorCode",
        //                "The 2fa token provided by the request was invalid. A valid 2fa token is required to enable 2fa.");
        //        }

        //        await userManager.SetTwoFactorEnabledAsync(user, true);
        //    }
        //    else if (tfaRequest.Enable == false || tfaRequest.ResetSharedKey)
        //    {
        //        await userManager.SetTwoFactorEnabledAsync(user, false);
        //    }

        //    if (tfaRequest.ResetSharedKey)
        //    {
        //        await userManager.ResetAuthenticatorKeyAsync(user);
        //    }

        //    string[]? recoveryCodes = null;
        //    if (tfaRequest.ResetRecoveryCodes || (tfaRequest.Enable == true && await userManager.CountRecoveryCodesAsync(user) == 0))
        //    {
        //        var recoveryCodesEnumerable = await userManager.GenerateNewTwoFactorRecoveryCodesAsync(user, 10);
        //        recoveryCodes = recoveryCodesEnumerable?.ToArray();
        //    }

        //    if (tfaRequest.ForgetMachine)
        //    {
        //        await signInManager.ForgetTwoFactorClientAsync();
        //    }

        //    var key = await userManager.GetAuthenticatorKeyAsync(user);
        //    if (string.IsNullOrEmpty(key))
        //    {
        //        await userManager.ResetAuthenticatorKeyAsync(user);
        //        key = await userManager.GetAuthenticatorKeyAsync(user);

        //        if (string.IsNullOrEmpty(key))
        //        {
        //            throw new NotSupportedException("The user manager must produce an authenticator key after reset.");
        //        }
        //    }

        //    return TypedResults.Ok(new TwoFactorResponse
        //    {
        //        SharedKey = key,
        //        RecoveryCodes = recoveryCodes,
        //        RecoveryCodesLeft = recoveryCodes?.Length ?? await userManager.CountRecoveryCodesAsync(user),
        //        IsTwoFactorEnabled = await userManager.GetTwoFactorEnabledAsync(user),
        //        IsMachineRemembered = await signInManager.IsTwoFactorClientRememberedAsync(user),
        //    });
        //});

        //accountGroup.MapGet("/info", async Task<Results<Ok<InfoResponse>, ValidationProblem, NotFound>>
        //    (ClaimsPrincipal claimsPrincipal, [FromServices] IServiceProvider sp) =>
        //{
        //    var userManager = sp.GetRequiredService<UserManager<TUser>>();
        //    if (await userManager.GetUserAsync(claimsPrincipal) is not { } user)
        //    {
        //        return TypedResults.NotFound();
        //    }

        //    return TypedResults.Ok(await CreateInfoResponseAsync(user, userManager));
        //});

        //accountGroup.MapPost("/info", async Task<Results<Ok<InfoResponse>, ValidationProblem, NotFound>>
        //    (ClaimsPrincipal claimsPrincipal, [FromBody] InfoRequest infoRequest, HttpContext context, [FromServices] IServiceProvider sp) =>
        //{
        //    var userManager = sp.GetRequiredService<UserManager<TUser>>();
        //    if (await userManager.GetUserAsync(claimsPrincipal) is not { } user)
        //    {
        //        return TypedResults.NotFound();
        //    }

        //    if (!string.IsNullOrEmpty(infoRequest.NewEmail) && !_emailAddressAttribute.IsValid(infoRequest.NewEmail))
        //    {
        //        return CreateValidationProblem(IdentityResult.Failed(userManager.ErrorDescriber.InvalidEmail(infoRequest.NewEmail)));
        //    }

        //    if (!string.IsNullOrEmpty(infoRequest.NewPassword))
        //    {
        //        if (string.IsNullOrEmpty(infoRequest.OldPassword))
        //        {
        //            return CreateValidationProblem("OldPasswordRequired",
        //                "The old password is required to set a new password. If the old password is forgotten, use /resetPassword.");
        //        }

        //        var changePasswordResult = await userManager.ChangePasswordAsync(user, infoRequest.OldPassword, infoRequest.NewPassword);
        //        if (!changePasswordResult.Succeeded)
        //        {
        //            return CreateValidationProblem(changePasswordResult);
        //        }
        //    }

        //    if (!string.IsNullOrEmpty(infoRequest.NewEmail))
        //    {
        //        var email = await userManager.GetEmailAsync(user);

        //        if (email != infoRequest.NewEmail)
        //        {
        //            await SendConfirmationEmailAsync(user, userManager, context, infoRequest.NewEmail, isChange: true);
        //        }
        //    }

        //    return TypedResults.Ok(await CreateInfoResponseAsync(user, userManager));
        //});

        //async Task SendConfirmationEmailAsync(TUser user, UserManager<TUser> userManager, HttpContext context, string email, bool isChange = false)
        //{
        //    if (confirmEmailEndpointName is null)
        //    {
        //        throw new NotSupportedException("No email confirmation endpoint was registered!");
        //    }

        //    var code = isChange
        //        ? await userManager.GenerateChangeEmailTokenAsync(user, email)
        //        : await userManager.GenerateEmailConfirmationTokenAsync(user);
        //    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

        //    var userId = await userManager.GetUserIdAsync(user);
        //    var routeValues = new RouteValueDictionary()
        //    {
        //        ["userId"] = userId,
        //        ["code"] = code,
        //    };

        //    if (isChange)
        //    {
        //        // This is validated by the /confirmEmail endpoint on change.
        //        routeValues.Add("changedEmail", email);
        //    }

        //    var confirmEmailUrl = linkGenerator.GetUriByName(context, confirmEmailEndpointName, routeValues)
        //        ?? throw new NotSupportedException($"Could not find endpoint named '{confirmEmailEndpointName}'.");

        //    await emailSender.SendConfirmationLinkAsync(user, email, HtmlEncoder.Default.Encode(confirmEmailUrl));
        //}

        //return new IdentityEndpointsConventionBuilder(routeGroup);
        //}
    }
}
