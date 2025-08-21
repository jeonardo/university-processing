using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.Converters;

public static class PagedListConverter
{
    public static PagedList<TDestination> Convert<TSource, TDestination>(
        PagedList<TSource> source,
        Func<TSource, TDestination> converter)
    {
        return new PagedList<TDestination>(
            source.Items.Select(converter),
            source.TotalCount,
            source.CurrentPage,
            source.PageSize);
    }
}
