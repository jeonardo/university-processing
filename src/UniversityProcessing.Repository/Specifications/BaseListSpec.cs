using System.Linq.Expressions;
using Ardalis.Specification;

namespace UniversityProcessing.Repository.Specifications;

public abstract class BaseListSpec<T> : Specification<T> where T : class
{
    private readonly string[] _availableProperties;

    protected BaseListSpec(
        string[] availableProperties,
        int pageNumber,
        int pageSize,
        string orderBy,
        bool desc,
        Expression<Func<T, bool>>? criteria = null)
    {
        _availableProperties = availableProperties;

        var offset = (pageNumber - 1) * pageSize;

        if (desc)
        {
            Query
                .AsNoTracking()
                .Where(criteria ?? (x => true))
                .OrderByDescending(x => ValidateOrderBy(orderBy))
                .Skip(offset)
                .Take(pageSize);
        }
        else
        {
            Query
                .AsNoTracking()
                .Where(criteria ?? (x => true))
                .OrderBy(x => ValidateOrderBy(orderBy))
                .Skip(offset)
                .Take(pageSize);
        }
    }

    private string ValidateOrderBy(string orderBy)
    {
        var trimmedOrderBy = orderBy.Trim().ToLower();

        return _availableProperties.Contains(trimmedOrderBy)
            ? trimmedOrderBy
            : _availableProperties.First();
    }
}
