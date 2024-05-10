using Ardalis.SharedKernel;
using Ardalis.Specification;

namespace UniversityProcessing.Repository.Repositories;

public interface IEfRepository<T> : IRepositoryBase<T>, IEfReadRepository<T> where T : class, IAggregateRoot
{
}