using FluentValidation;
using UniversityProcessing.GenericSubdomain.Validation;

namespace UniversityProcessing.API.Endpoints.Auth.Registration.Register;

public sealed class RegisterRequestDtoValidator : AbstractValidator<RegisterRequestDto>
{
    public RegisterRequestDtoValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("Username is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.Password)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("Password is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("First name is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("Last name is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.Email)
            .EmailAddress()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("Email must be valid. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.MiddleName)
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("MiddleName must be valid. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.UniversityPositionId)
            .NotEmpty()
            .When(x => x.Role is UserRoleDto.Deanery or UserRoleDto.Teacher)
            .WithMessage("University position is required");

        RuleFor(x => x.GroupNumber)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .When(x => x.Role is UserRoleDto.Student)
            .WithMessage("Group number is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.Role)
            .NotEmpty()
            .IsInEnum()
            .WithMessage("Role is required and must be in the enum");

        RuleFor(x => x.FacultyId)
            .NotEmpty()
            .When(x => x.Role is UserRoleDto.Deanery or UserRoleDto.Teacher)
            .WithMessage("Faculty is required");

        RuleFor(x => x.DepartmentId)
            .NotEmpty()
            .When(x => x.Role is UserRoleDto.Teacher)
            .WithMessage("Department is required");
    }
}
