using FluentValidation;
using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.Periods.Get;

public sealed class GetPeriodsRequestDtoValidator : AbstractValidator<GetPeriodsRequestDto>
{
    public GetPeriodsRequestDtoValidator()
    {
    }
}
