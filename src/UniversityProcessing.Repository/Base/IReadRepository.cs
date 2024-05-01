using Ardalis.Specification;

namespace UniversityProcessing.Repository.Base;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}