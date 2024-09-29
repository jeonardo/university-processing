// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global

namespace UniversityProcessing.GenericSubdomain.Pagination;

public sealed class PagedList<T>(IEnumerable<T> items, int count, int pageNumber, int pageSize)
{
    public IEnumerable<T> Items { get; private set; } = items;
    public int CurrentPage { get; private set; } = pageNumber;
    public int TotalPages { get; private set; } = (int)Math.Ceiling(count / (double)pageSize);
    public int PageSize { get; private set; } = pageSize;
    public int TotalCount { get; private set; } = count;

    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;
}
