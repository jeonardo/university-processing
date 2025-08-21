namespace StoreTest.Admin.Faculties.Get;

public sealed class GetFacultiesRequestDtoValidator : AbstractValidator<GetFacultiesRequestDto>
{
    public GetFacultiesRequestDtoValidator()
    {
        Include(new BaseGetListQueryParametersValidator());
    }
}
