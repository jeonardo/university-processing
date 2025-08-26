using FluentValidation;
using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.Users.GetTeachers;

public sealed class GetTeachersRequestDtoValidator : AbstractValidator<GetTeachersRequestDto>
{
    public GetTeachersRequestDtoValidator()
    {
        Include(new BaseGetListQueryParametersValidator());
    }
}
