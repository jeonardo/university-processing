namespace StoreTest.TODO.Endpoints.Employee.Teacher.DepartmentLeader.Groups.Create;

public sealed class CreateGroupRequestDtoValidator : AbstractValidator<CreateGroupRequestDto>
{
    public CreateGroupRequestDtoValidator()
    {
        RuleFor(x => x.GroupNumber)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("GroupNumber is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.SpecialtyId)
            .NotEmpty()
            .WithMessage("Specialty is required");

        RuleFor(x => x.StartDate)
            .NotEmpty()
            .WithMessage("StartDate is required");

        RuleFor(x => x.EndDate)
            .NotEmpty()
            .WithMessage("EndDate is required");
    }
}
