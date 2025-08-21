using FluentValidation;
using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.Admin.Faculties.Get;

public sealed class GetFacultiesRequestDtoValidator : AbstractValidator<GetFacultiesRequestDto>
{
    public GetFacultiesRequestDtoValidator()
    {
        Include(new BaseGetListQueryParametersValidator());
    }
}
