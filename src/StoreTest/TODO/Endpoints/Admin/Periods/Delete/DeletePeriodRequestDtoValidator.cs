namespace StoreTest.TODO.Endpoints.Admin.Periods.Delete;

public sealed class DeletePeriodRequestDtoValidator : AbstractValidator<DeletePeriodRequestDto>
{
    public DeletePeriodRequestDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required");
    }
}
