using System.ComponentModel;

namespace UniversityProcessing.GenericSubdomain.Pagination;

public abstract class BaseGetListQueryParameters
{
    private const int MAX_PAGE_SIZE = 100;

    [DefaultValue(false)]
    public bool? Desc { get; set; }

    [DefaultValue("id")]
    public string? OrderBy { get; set; }

    [DefaultValue(1)]
    public int? PageNumber { get; set; }

    [DefaultValue(MAX_PAGE_SIZE)]
    public int? PageSize { get; set; }

    public string? Filter { get; set; }

    public GetListQueryParameters GetValidQueryParameters()
    {
        const int defaultNumber = 1;
        const int defaultSize = 10;
        const bool defaultDesc = false;
        const string defaultOrderBy = "id";
        const string defaultFilter = "";
        return new GetListQueryParameters(
            PageNumber.GetValueOrDefault() > defaultNumber
                ? PageNumber.GetValueOrDefault()
                : defaultNumber,
            PageSize.GetValueOrDefault() is > MAX_PAGE_SIZE or <= 0
                ? defaultSize
                : PageSize.GetValueOrDefault(),
            Desc ?? defaultDesc,
            OrderBy ?? defaultOrderBy,
            Filter ?? defaultFilter);
    }
}
