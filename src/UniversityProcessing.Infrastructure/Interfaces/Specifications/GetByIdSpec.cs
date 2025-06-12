using Ardalis.Specification;
using UniversityProcessing.GenericSubdomain.Identity;

namespace UniversityProcessing.Infrastructure.Interfaces.Specifications;

public sealed class GetByIdSpec<T> : Specification<T> where T : class, IHasId
{
    public GetByIdSpec(Guid id)
    {
        Query
            .AsNoTracking()
            .Where(x => x.Id == id);
    }
}
