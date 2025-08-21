using System.Linq.Expressions;
using StoreTest.Services.Auth;

namespace StoreTest.Admin.GetUsers;

internal sealed class GetUsers : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(GetUsers);
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.Admin)));
    }

    private static async Task<GetUsersResponseDto> Handle(
        HttpContext context,
        [AsParameters] GetUsersRequestDto request,
        [FromServices] UserManager<User> userManager,
        [FromServices] ITokenService tokenService,
        CancellationToken cancellationToken)
    {
        var claims = tokenService.GetAuthorizationTokenClaims(context.User);
        var pagedList = await userManager.Users.ToPagedListAsync(request, GetFilterExpression(claims), cancellationToken);
        return new GetUsersResponseDto(PagedListConverter.Convert(pagedList, ToDto));
    }

    private static Expression<Func<User, bool>> GetFilterExpression(AuthTokenClaims authTokenClaims)
    {
        return authTokenClaims switch
        {
            _ => throw new ArgumentOutOfRangeException(nameof(authTokenClaims))
        };
    }

    private static UserDto ToDto(User input)
    {
        return new UserDto(input.Id, input.FirstName, input.LastName, input.MiddleName, input.Approved);
    }
}
