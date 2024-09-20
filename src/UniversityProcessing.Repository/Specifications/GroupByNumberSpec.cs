using Ardalis.Specification;
using UniversityProcessing.Domain.UniversityStructure;

namespace UniversityProcessing.Repository.Specifications;

public sealed class GroupByNumberSpec : Specification<Group>
{
    public GroupByNumberSpec(string number)
    {
        Query
            .AsNoTracking()
            .Where(x => x.Number == number);
    }
}
