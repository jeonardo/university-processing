using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.GenericSubdomain.Endpoints;

namespace UniversityProcessing.API.Endpoints.Identity.Logout;

internal sealed class Logout : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app
            .MapPost(nameof(Logout), Handle)
            .WithTags(Tags.IDENTITY)
            .RequireAuthorization();
    }

    private static Task Handle([FromServices] SignInManager<User> signInManager)
    {
        return signInManager.SignOutAsync();
    }
}
