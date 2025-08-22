using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using UniversityProcessing.API.Endpoints.Auth.Registration.Common.Forms;
using UniversityProcessing.Domain;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Infrastructure;
using UniversityProcessing.Utils.Identity;
using UniversityProcessing.Utils.Middlewares.Exceptions;

namespace UniversityProcessing.API.Endpoints.Auth.Registration.Common;

internal sealed class RegistrationService(
    ApplicationDbContext dbContext,
    UserManager<User> userManager,
    ILogger<RegistrationService> logger) : IRegistrationService
{
    public async Task Register(IRegistrationForm registrationForm, UserRoleType role, CancellationToken cancellationToken)
    {
        var user = await BuildUser(registrationForm, role, cancellationToken);

        var createResult = await userManager.CreateAsync(user, registrationForm.Password);

        if (createResult.IsFailed())
        {
            throw new ConflictException($"Registration failed. Message = {createResult.FullDescription()}");
        }

        var addToRoleResult = await userManager.AddToRoleAsync(user, role.GetDisplayName());

        if (addToRoleResult.IsFailed())
        {
            var deleteResult = await userManager.DeleteAsync(user);

            if (deleteResult.IsFailed())
            {
                logger.LogError("Registration failed but user wasn't removed");
            }

            throw new ConflictException($"Registration failed. Message = {addToRoleResult.FullDescription()}");
        }
    }

    public async Task Verify(string userName)
    {
        var user = await userManager.FindByNameAsync(userName);

        if (user is null)
        {
            throw new NotFoundException($"The user with username = {userName} not found");
        }

        user.UpdateVerificationStatus(true);

        var updateResult = await userManager.UpdateAsync(user);

        if (updateResult.IsFailed())
        {
            throw new ConflictException(updateResult.FullDescription());
        }
    }

    private async Task<User> BuildUser(IRegistrationForm form, UserRoleType role, CancellationToken cancellationToken)
    {
        switch (role)
        {
            case UserRoleType.Admin:

                if (form is not IAdminRegistrationForm adminForm)
                {
                    throw new ArgumentException($"{nameof(form)} is not IAdminRegistrationForm", nameof(form));
                }

                return new Admin(
                    adminForm.UserName,
                    adminForm.FirstName,
                    adminForm.LastName,
                    adminForm.MiddleName,
                    adminForm.Email,
                    adminForm.Birthday);

            case UserRoleType.Deanery:

                if (form is not IDeaneryRegistrationForm deaneryForm)
                {
                    throw new ArgumentException($"{nameof(form)} is not IDeaneryRegistrationForm", nameof(form));
                }

                return new Deanery(
                    deaneryForm.UserName,
                    deaneryForm.FirstName,
                    deaneryForm.LastName,
                    deaneryForm.MiddleName,
                    deaneryForm.Email,
                    deaneryForm.Birthday,
                    deaneryForm.UniversityPositionId,
                    deaneryForm.FacultyId);

            case UserRoleType.Teacher:

                if (form is not ITeacherRegistrationForm teacherForm)
                {
                    throw new ArgumentException($"{nameof(form)} is not ITeacherRegistrationForm", nameof(form));
                }

                return new Teacher(
                    teacherForm.UserName,
                    teacherForm.FirstName,
                    teacherForm.LastName,
                    teacherForm.MiddleName,
                    teacherForm.Email,
                    teacherForm.Birthday,
                    teacherForm.UniversityPositionId,
                    teacherForm.DepartmentId);

            case UserRoleType.Student:

                if (form is not IStudentRegistrationForm studentForm)
                {
                    throw new ArgumentException($"{nameof(form)} is not IStudentRegistrationForm", nameof(form));
                }

                var group = await GetRequiredGroup(studentForm.GroupNumber, cancellationToken);

                return new Student(
                    studentForm.UserName,
                    studentForm.FirstName,
                    studentForm.LastName,
                    studentForm.MiddleName,
                    studentForm.Email,
                    studentForm.Birthday,
                    group.Id);

            default:
                throw new ArgumentOutOfRangeException(nameof(role), role, null);
        }
    }

    private async Task<Group> GetRequiredGroup(string groupNumber, CancellationToken cancellationToken)
    {
        var group = await dbContext.Groups
            .Where(x => x.Number == groupNumber)
            .ToArrayAsync(cancellationToken);

        switch (group.Length)
        {
            case 0:
                throw new NotFoundException($"Group with number {groupNumber} not found");
            case > 1:
                throw new ConflictException($"Group with number {groupNumber} is not unique");
        }

        return group[0];
    }
}
