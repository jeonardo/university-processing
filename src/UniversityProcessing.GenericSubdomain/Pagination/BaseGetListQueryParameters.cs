using System.ComponentModel;

namespace UniversityProcessing.GenericSubdomain.Pagination;

public abstract class BaseGetListQueryParameters
{
    private const int MAX_PAGE_SIZE = 100;

    private int _pageSize = 10;
    private int _pageNumber = 1;

    [DefaultValue(false)]
    public bool Desc { get; set; }

    [DefaultValue("id")]
    public string OrderBy { get; set; } = "id";

    [DefaultValue(1)]
    public int PageNumber
    {
        get => _pageNumber;
        set =>
            _pageNumber = value > _pageNumber
                ? value
                : _pageNumber;
    }

    [DefaultValue(MAX_PAGE_SIZE)]
    public int PageSize
    {
        get => _pageSize;
        set =>
            _pageSize = value is > MAX_PAGE_SIZE or <= 0
                ? _pageSize
                : value;
    }

    public string? Filter { get; set; }
}
