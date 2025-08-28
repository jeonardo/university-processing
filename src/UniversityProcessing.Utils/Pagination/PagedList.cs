// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global

namespace UniversityProcessing.Utils.Pagination;

public class PagedList<T>(IEnumerable<T> items, int count, int currentPage, int pageSize)
{
    public IEnumerable<T> Items { get; private set; } = items;
    public int CurrentPage { get; private set; } = currentPage;
    public int TotalPages { get; private set; } = (int)Math.Ceiling(count / (double)pageSize);
    public int PageSize { get; private set; } = pageSize;
    public int TotalCount { get; private set; } = count;

    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;

    public PagedList(PagedList<T> pagedList) : this(pagedList.Items, pagedList.TotalCount, pagedList.CurrentPage, pagedList.PageSize)
    {
    }
}
