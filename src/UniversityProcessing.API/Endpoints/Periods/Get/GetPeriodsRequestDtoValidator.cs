using FluentValidation;
using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.Periods.Get;

internal sealed class GetPeriodsRequestDtoValidator : AbstractValidator<GetPeriodsRequestDto>
{
    public GetPeriodsRequestDtoValidator()
    {
        Include(new BaseGetListQueryParametersValidator());
    }
}
