using System.Linq.Expressions;
using Ardalis.Specification;

namespace UniversityProcessing.Repository.Specifications;

public abstract class BaseListSpec<T> : Specification<T> where T : class
{
    protected virtual string[] AvailableProperties => [];

    protected BaseListSpec(
        int pageNumber,
        int pageSize,
        string? orderBy = null,
        bool desc = false,
        Expression<Func<T, bool>>? expression = null)
    {
        Query.Where(x => true);

        // var offset = (pageNumber - 1) * pageSize;
        //
        // // ReSharper disable once VirtualMemberCallInConstructor
        // var query = Query
        //     .AsNoTracking()
        //     .Where(expression ?? (x => true));
        //
        // // ReSharper disable once VirtualMemberCallInConstructor
        // if (AvailableProperties.Length != 0)
        // {
        //     var validatedOrderBy = ValidateOrderBy(orderBy);
        //
        //     query = desc
        //         ? query.OrderByDescending(x => validatedOrderBy)
        //         : query.OrderBy(x => validatedOrderBy);
        // }
        //
        // query
        //     .Skip(offset)
        //     .Take(pageSize);
    }

    private string ValidateOrderBy(string? orderBy)
    {
        return orderBy is not null && AvailableProperties.Contains(orderBy)
            ? orderBy
            : AvailableProperties.First();
    }
}
