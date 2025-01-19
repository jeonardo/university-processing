namespace UniversityProcessing.GenericSubdomain.Pagination;

public sealed record GetListQueryParameters(int PageNumber, int PageSize, bool Desc, string OrderBy, string Filter, bool IsFilterSet);
