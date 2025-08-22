using Ardalis.SharedKernel;
using Ardalis.Specification;

namespace UniversityProcessing.Infrastructure.Interfaces.Repositories;

public interface IEfRepository<T> : IRepositoryBase<T>, IEfReadRepository<T> where T : class, IAggregateRoot;
