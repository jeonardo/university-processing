using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Domain;
using UniversityProcessing.GenericSubdomain.Endpoints;
using UniversityProcessing.GenericSubdomain.Filters;
using UniversityProcessing.GenericSubdomain.Identity;
using UniversityProcessing.GenericSubdomain.Middlewares.Exceptions;
using UniversityProcessing.GenericSubdomain.Routing;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.API.Endpoints.Registration.Student.Register;

internal sealed class RegisterStudent : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(RegisterStudent);
        app
            .MapPost(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .AddEndpointFilter<ValidationFilter<RegisterStudentRequestDto>>();
    }

    private static async Task Handle(
        [FromBody] RegisterStudentRequestDto request,
        [FromServices] UserManager<User> userManager,
        [FromServices] ILogger<RegisterStudent> logger,
        [FromServices] IEfReadRepository<Group> groupRepository,
        CancellationToken cancellationToken)
    {
        var groupId = await GetGroupId();

        var user = User.CreateStudent(
            request.UserName,
            request.FirstName,
            request.LastName,
            request.MiddleName,
            request.Email,
            request.Birthday,
            groupId);

        var createResult = await userManager.CreateAsync(user, request.Password);

        if (createResult.IsFailed())
        {
            throw new ConflictException($"Registration failed. Message = {string.Join("; ", createResult.Errors)}");
        }

        var addToRoleResult = await userManager.AddToRoleAsync(user, nameof(UserRoleType.Student));

        if (!addToRoleResult.IsFailed())
        {
            return;
        }

        var deleteResult = await userManager.DeleteAsync(user);

        if (deleteResult.IsFailed())
        {
            logger.LogError("Registration failed but user wasn't removed");
        }

        throw new ConflictException($"Registration failed. Message = {string.Join("; ", addToRoleResult.Errors)}");

        async Task<Guid?> GetGroupId()
        {
            if (request.GroupNumber is null)
            {
                return null;
            }

            var group = await groupRepository.FirstOrDefaultAsync(new GroupByNumberSpec(request.GroupNumber), cancellationToken);

            if (group is null)
            {
                throw new NotFoundException($"Group with number {request.GroupNumber} not found");
            }

            return group.Id;
        }
    }
}
