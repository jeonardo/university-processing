using System.Linq.Expressions;
using Ardalis.Specification;

// ReSharper disable VirtualMemberCallInConstructor

namespace UniversityProcessing.Infrastructure.Interfaces.Specifications;

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
        Query
            .AsNoTracking()
            .Where(expression ?? (x => true));

        if (AvailableProperties.Length != 0)
        {
            var validatedOrderBy = ValidateOrderBy(orderBy);

            if (desc)
            {
                Query.OrderByDescending(x => validatedOrderBy);
            }
            else
            {
                Query.OrderBy(x => validatedOrderBy);
            }
        }

        var offset = (pageNumber - 1) * pageSize;

        Query
            .Skip(offset)
            .Take(pageSize);
    }

    private string ValidateOrderBy(string? orderBy)
    {
        return orderBy is not null && AvailableProperties.Contains(orderBy)
            ? orderBy
            : AvailableProperties.First();
    }
}
