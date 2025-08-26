using FluentValidation;
using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.Users.GetAdmins;

public sealed class GetAdminsRequestDtoValidator : AbstractValidator<GetAdminsRequestDto>
{
    public GetAdminsRequestDtoValidator()
    {
        Include(new BaseGetListQueryParametersValidator());
    }
}
