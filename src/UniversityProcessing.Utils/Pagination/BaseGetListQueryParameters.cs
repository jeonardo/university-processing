using System.ComponentModel;

namespace UniversityProcessing.Utils.Pagination;

public abstract class BaseGetListQueryParameters
{
    [DefaultValue(1)]
    public int PageNumber { get; set; } = 1;

    [DefaultValue(20)]
    public int PageSize { get; set; } = 20;

    public string? Filter { get; set; }
    public bool? Desc { get; set; }
    public string? OrderBy { get; set; }
}
