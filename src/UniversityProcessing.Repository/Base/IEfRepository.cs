using Ardalis.SharedKernel;

namespace UniversityProcessing.Repository.Base;

public interface IEfRepository<T> : IReadRepository<T>, IRepository<T>
    where T : class, IAggregateRoot;