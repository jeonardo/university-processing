using FluentValidation;

namespace UniversityProcessing.Utils.Pagination;

public sealed class BaseGetListQueryParametersValidator : AbstractValidator<BaseGetListQueryParameters>
{
    public BaseGetListQueryParametersValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1)
            .WithMessage("PageNumber must be at least 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1)
            .WithMessage("PageSize must be at least 1.")
            .LessThanOrEqualTo(100)
            .WithMessage("PageSize cannot exceed 100.");

        RuleFor(x => x.Filter)
            .MaximumLength(100)
            .When(x => !string.IsNullOrWhiteSpace(x.Filter))
            .WithMessage("Filter cannot exceed 100 characters.");

        RuleFor(x => x.OrderBy)
            .MaximumLength(50)
            .When(x => !string.IsNullOrWhiteSpace(x.OrderBy))
            .WithMessage("OrderBy cannot exceed 50 characters.");
    }
}
