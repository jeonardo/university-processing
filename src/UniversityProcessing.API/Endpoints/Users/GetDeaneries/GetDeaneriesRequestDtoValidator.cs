using FluentValidation;
using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.Users.GetDeaneries;

public sealed class GetDeaneriesRequestDtoValidator : AbstractValidator<GetDeaneriesRequestDto>
{
    public GetDeaneriesRequestDtoValidator()
    {
        Include(new BaseGetListQueryParametersValidator());
    }
}
