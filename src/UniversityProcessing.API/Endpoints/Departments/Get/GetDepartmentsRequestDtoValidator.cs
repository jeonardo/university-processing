using FluentValidation;
using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.Departments.Get;

public sealed class GetDepartmentsRequestDtoValidator : AbstractValidator<GetDepartmentsRequestDto>
{
    public GetDepartmentsRequestDtoValidator()
    {
        Include(new BaseGetListQueryParametersValidator());
    }
}
