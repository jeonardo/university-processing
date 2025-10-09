using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace UniversityProcessing.Utils.Pagination;

public static class QueryExtensions
{
    public static async Task<PagedList<TResult>> ToPagedListAsync<T, TResult>(
        this IQueryable<T> source,
        BaseGetListQueryParameters parameters,
        Expression<Func<T, bool>>? filter = null,
        Expression<Func<T, TResult>>? select = null,
        Expression<Func<T, IEnumerable<TResult>>>? selectMany = null,
        Func<IQueryable<T>, IQueryable<T>>? includes = null,
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

        if (includes is not null)
        {
            source = includes(source);
        }

        // Apply filtering
        if (filter is not null)
        {
            source = source.Where(filter);
        }

        var count = await source.CountAsync(cancellationToken);

        // Apply ordering
        var orderedSource = ApplyOrdering(source, parameters);

        // Apply paging
        var pagedSource = orderedSource
            .Skip((parameters.PageNumber - 1) * parameters.PageSize)
            .Take(parameters.PageSize);

        TResult[] items;

        if (selectMany is not null)
        {
            items = await pagedSource.SelectMany(selectMany).ToArrayAsync(cancellationToken);
        }
        else if (select is not null)
        {
            items = await pagedSource.Select(select).ToArrayAsync(cancellationToken);
        }
        else if (typeof(TResult) == typeof(T))
        {
            items = (TResult[])(object)await pagedSource.ToArrayAsync(cancellationToken);
        }
        else
        {
            throw new InvalidOperationException($"Cannot project {typeof(T)} to {typeof(TResult)}. Provide a select expression.");
        }

        return new PagedList<TResult>(items, count, parameters.PageNumber, parameters.PageSize);
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
