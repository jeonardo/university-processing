using FluentValidation;
using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.Users.GetStudents;

public sealed class GetStudentsRequestDtoValidator : AbstractValidator<GetStudentsRequestDto>
{
    public GetStudentsRequestDtoValidator()
    {
        Include(new BaseGetListQueryParametersValidator());
    }
}
