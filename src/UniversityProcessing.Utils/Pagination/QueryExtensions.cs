using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace UniversityProcessing.Utils.Pagination;

public static class QueryExtensions
{
    public static async Task<PagedList<T>> ToPagedListAsync<T>(
        this IQueryable<T> source,
        BaseGetListQueryParameters parameters,
        Expression<Func<T, bool>>? filter = null,
        CancellationToken cancellationToken = default) where T : class
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(parameters);

        if (parameters.PageNumber < 1)
        {
            throw new ArgumentException("PageNumber must be greater than 0", nameof(parameters));
        }

        if (parameters.PageSize < 0)
        {
            throw new ArgumentException("PageSize must be non-negative", nameof(parameters));
        }

        source = source.AsNoTracking();

        // Apply filtering
        if (filter is not null)
        {
            source = source.Where(filter);
        }

        var totalCount = await source.CountAsync(cancellationToken);

        // Apply ordering
        source = ApplyOrdering(source, parameters);

        // Apply pagination
        if (parameters.PageSize > 0)
        {
            source = source
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize);
        }

        return new PagedList<T>(
            await source.ToListAsync(cancellationToken),
            totalCount,
            parameters.PageNumber,
            parameters.PageSize);
    }

    private static IQueryable<T> ApplyOrdering<T>(IQueryable<T> source, BaseGetListQueryParameters parameters)
        where T : class
    {
        if (string.IsNullOrWhiteSpace(parameters.OrderBy))
        {
            return source;
        }

        return parameters.Desc.GetValueOrDefault()
            ? source.OrderBy($"{parameters.OrderBy} DESC")
            : source.OrderBy(parameters.OrderBy);
    }
}
